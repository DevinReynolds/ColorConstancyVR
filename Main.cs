using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System.Xml;
using System;

public class Main : MonoBehaviour
{
    // Creates variables
    public int numberOfstereoscopicImagePairs;
    public int iteration;
    public bool wait;
    public bool waitAfterBreakForInput;
    public int[] userInput;
    public int[] comparisonImageOrderDisplayed;
    public string subjectName;
    public string condition;
    public string[] comparisonImageOrder_LightnessName;
    public string[] comparisonImageOrder_ImageNumber;
    public string[] standardImageOrderNumber;
    public int numberOfConditions;
    public int numberOfTimesEachConditionIsRan;
    AudioSource audioData;

    // Displays the images on the image scene after a timer.
    // j is used to determine wether both the comparison and standard imaage
    // displayed. j is set to two before either image is displayed.
    public IEnumerator DispImage(int ranOrder, int j)
    {      
        Texture2D leftTex;
        Texture2D rightTex;

        // Finds the standard and comparison images by the order specified by ranOrder
        if (ranOrder == 1)
        {
            // Finds the standard images
            // Finds the textures for the left and right images
            leftTex = (Texture2D)Resources.Load("Conditions/" + condition + "/luminance-0_4000-reflectance-" + standardImageOrderNumber[iteration] + "-BigBall-Library", typeof(Texture2D));
            rightTex = (Texture2D)Resources.Load("Conditions/" + condition + "/luminance-0_4000-reflectance-" + standardImageOrderNumber[iteration] + "-BigBall-Library_camera2", typeof(Texture2D));
            j--;
            ranOrder = 0;
        } // if
        else
        {
            // Finds the comparison image
            // Finds the textures for the left and right images
            leftTex = (Texture2D)Resources.Load("Conditions/" + condition + "/luminance-0_" + comparisonImageOrder_LightnessName[iteration - 1] + "-reflectance-" + comparisonImageOrder_ImageNumber[iteration] + "-BigBall-Library", typeof(Texture2D));
            rightTex = (Texture2D)Resources.Load("Conditions/" + condition + "/luminance-0_" + comparisonImageOrder_LightnessName[iteration - 1] + "-reflectance-" + comparisonImageOrder_ImageNumber[iteration] + "-BigBall-Library_camera2", typeof(Texture2D));
            j--;
            ranOrder = 1;
        } // else

        yield return new WaitForSecondsRealtime(.15f);

        GameObject dot = GameObject.FindGameObjectWithTag("Dot");
        dot.GetComponent<MeshRenderer>().enabled = false;        

        // Finds the left object and applies the left texture
        GameObject leftEyeImageDisp = GameObject.FindGameObjectWithTag("LeftEyeImage");
        leftEyeImageDisp.GetComponent<Renderer>().material.mainTexture = leftTex;

        // Finds the right object and applies the right texture
        GameObject rightEyeImageDisp = GameObject.FindGameObjectWithTag("RightEyeImage");
        rightEyeImageDisp.gameObject.GetComponent<Renderer>().material.mainTexture = rightTex;

        yield return new WaitForSecondsRealtime(.15f);

        dot.GetComponent<MeshRenderer>().enabled = false;

        // Finds a black texture and applies it to the left and right game objects
        Texture2D blackTex;
        blackTex = (Texture2D)Resources.Load("Black", typeof(Texture2D));
        leftEyeImageDisp.GetComponent<Renderer>().material.mainTexture = blackTex;
        rightEyeImageDisp.gameObject.GetComponent<Renderer>().material.mainTexture = blackTex;

        // Checks to see if both the comparison and standard image have been displayed
        // then displays the second image if it has not been displayed yet or waits
        // for the user input.
        if (j == 1)
        {
            yield return new WaitForSecondsRealtime(.15f);
            StartCoroutine(DispImage(ranOrder, j));
        } // if
        else
        { 
            wait = true;
        } // else
    } // DispImage

    // Break for when the experiment is 1/3 or 2/3s done.
    public IEnumerator SubjectBreak()
    {
        // Finds the dot object and the red and green textures
        Texture2D redTex;
        Texture2D greenTex;
        redTex = (Texture2D)Resources.Load("Red", typeof(Texture2D));
        greenTex = (Texture2D)Resources.Load("Green", typeof(Texture2D));
        GameObject dot = GameObject.FindGameObjectWithTag("Dot");

        // Sets the dot to red
        dot.gameObject.GetComponent<Renderer>().material.mainTexture = redTex;

        yield return new WaitForSecondsRealtime(5f);
        waitAfterBreakForInput = true;
       
        // Sets the dot to green
        dot.gameObject.GetComponent<Renderer>().material.mainTexture = greenTex;
    } // SubjectBreak

    // Called every frame.
    // Used to detect imputs.
    public void Update()
    {
        // Checks if waiting on input, checks for input and then changes scene
        if (wait)
        {

            // Returns true if the button is pressed
            //bool FirstImageChosen = Input.GetButtonDown("Fire2");
            bool FirstImageChosen = Input.GetButtonDown("Jump");
            //bool secondImageChosen = Input.GetButtonDown("Jump");
            bool secondImageChosen = Input.GetButtonDown("Submit");

            if (secondImageChosen | FirstImageChosen)
            {
                wait = false;

                // Checks which button was pressed and writes it to userInput
                if (FirstImageChosen)
                {
                    userInput[iteration] = 0;
                } // if
                else
                {
                    userInput[iteration] = 1;
                } // else

                if (iteration != 0)
                {
                    if (((userInput[iteration] == comparisonImageOrderDisplayed[iteration - 1]) && (Int32.Parse(comparisonImageOrder_LightnessName[iteration - 1]) > 4000)) 
                        || ((userInput[iteration] != comparisonImageOrderDisplayed[iteration - 1]) && (Int32.Parse(comparisonImageOrder_LightnessName[iteration - 1]) < 4000))) // Plays correct sound if the comparison image is chosen and is lighter than 0.4000
                    {
                        GameObject CorrectSoundObject = GameObject.FindGameObjectWithTag("CorrectSound");
                        audioData = CorrectSoundObject.GetComponent<AudioSource>();
                        audioData.Play(0);
                    } // if
                    else // Else plays incorrect sound
                    {
                        GameObject IncorrectSoundObject = GameObject.FindGameObjectWithTag("IncorrectSound");
                        audioData = IncorrectSoundObject.GetComponent<AudioSource>();
                        audioData.Play(0);
                    } // else
                } // if
                Control();
            } // if
        } // if

        // If the break has finished,
        // continue the experiment when a button is pressed.
        if (waitAfterBreakForInput)
        {
            // Returns true if the button is pressed
            bool FirstImageChosen = Input.GetButtonDown("Jump");
            bool secondImageChosen = Input.GetButtonDown("Submit");

            // Continues when a button is pressed
            if (secondImageChosen | FirstImageChosen)
            {
                waitAfterBreakForInput = false;

                // ranOrder selects the order at which the comparison and standard images are displayed.
                var rand = new System.Random();
                int ranOrder = rand.Next(0, 2);
                comparisonImageOrderDisplayed[iteration] = ranOrder;

                iteration += 1;
                StartCoroutine(DispImage(ranOrder, 2));
            } // if
        } // if
    } // Update

    // Initialize variables then sets wait to true.
    public void StartAquisition(string name, string conditionName, string imageOrder, int numConditions, int numConditonRan, string stanOrder)
    {
        //Initialize variables
        subjectName = name;
        condition = conditionName;
        numberOfConditions = numConditions;
        numberOfTimesEachConditionIsRan = numConditonRan;
        iteration = 0;

        // Splits the image order sting into a array using "|" as 
        // the split indicator.
        string[] comparisonImageOrderTemp = imageOrder.Split('|');
        string[] standardImageOrderTemp = stanOrder.Split('|');

        //Initialize variables
        numberOfstereoscopicImagePairs = (comparisonImageOrderTemp.Length - 1) / 2;
        userInput = new int[1 + numberOfstereoscopicImagePairs];
        comparisonImageOrderDisplayed = new int[numberOfstereoscopicImagePairs];

        // Splits the array comparisonImageOrderTemp into two array;
        // one array for the lighness name and another for the image order.
        // The IEnumerator method cannot handle multidimensional arrays so 
        // two arrays must be used.
        comparisonImageOrder_LightnessName = new string[numberOfstereoscopicImagePairs];
        comparisonImageOrder_ImageNumber = new string[numberOfstereoscopicImagePairs];
        for (int i = 0; i < (comparisonImageOrderTemp.Length - 1); i++)
        {
            comparisonImageOrder_LightnessName[i / 2] = comparisonImageOrderTemp[i];
            i++;

            // Turns single and double digit image numbers into a triple
            // digit image number. EX: 1 -> 001  EX: 10 -> 010
            switch (comparisonImageOrderTemp[i].Length)
            {
                case 1:
                    comparisonImageOrder_ImageNumber[i / 2] = "00" + comparisonImageOrderTemp[i];
                    break;
                case 2:
                    comparisonImageOrder_ImageNumber[i / 2] = "0" + comparisonImageOrderTemp[i];
                    break;
                default:
                    comparisonImageOrder_ImageNumber[i / 2] = comparisonImageOrderTemp[i];
                    break;
            } // switch
        } // for

        // Puts the standard image order into the correct format.
        standardImageOrderNumber = new string[numberOfstereoscopicImagePairs];
        for (int i = 0; i < numberOfstereoscopicImagePairs; i++)
        { 
            // Turns single and double digit image numbers into a triple
            // digit image number. EX: 1 -> 001  EX: 10 -> 010
            switch (standardImageOrderTemp[i].Length)
            {
                case 1:
                    standardImageOrderNumber[i] = "00" + standardImageOrderTemp[i];
                    break;
                case 2:
                    standardImageOrderNumber[i] = "0" + standardImageOrderTemp[i];
                    break;
                default:
                    standardImageOrderNumber[i] = standardImageOrderTemp[i];
                    break;
            } // switch
        } // for
        wait = true;
    } // StartAquisition

    // Controls the iteration number for the amount of images diaplayed.
    public void Control()
    {
        // Runs code until all the images are displayed then saves the user input as a xml file.
        if (iteration < (numberOfstereoscopicImagePairs - 1))
        {
            if ((iteration == (numberOfstereoscopicImagePairs / 3)) || (iteration == ((numberOfstereoscopicImagePairs / 3) * 2))) // If 1/3 or 2/3s done, start break
            {
                StartCoroutine(SubjectBreak());
            } else
            {
                // ranOrder selects the order at which the comparison and standard images are displayed.
                var rand = new System.Random();
                int ranOrder = rand.Next(0, 2);
                comparisonImageOrderDisplayed[iteration] = ranOrder;

                iteration += 1;
                StartCoroutine(DispImage(ranOrder, 2));
            }          
        } // if
        else
        {
            // Compares userInput to comparisonImageOrderDisplayed
            // to determine if the comparison image was chosen
            // and saves that to a string.
            string wasTheComparisonImageChosenString = "";
            string[] wasTheComparisonImageChosen = new string[numberOfstereoscopicImagePairs];
            for (int i = 0; i < numberOfstereoscopicImagePairs; i++)
            {
                if (userInput[i + 1] == comparisonImageOrderDisplayed[i])
                {
                    wasTheComparisonImageChosen[i] = "YES";
                } // if
                else
                {
                    wasTheComparisonImageChosen[i] = "NO";
                } // else
                wasTheComparisonImageChosenString += wasTheComparisonImageChosen[i] + "|";
            } // for

            // Loads the xml doument.
            XmlDocument doc = new XmlDocument();
            doc.Load("subjects/" + subjectName + "/" + subjectName + ".xml");

            // Gets the root and the ComparisonImageChosen nodes.
            XmlNode root = doc.FirstChild;
            XmlNode ComparisonImageChosen = root.ChildNodes[2];

            // Saves the data.
            for (int i = 0; i < (numberOfConditions * numberOfTimesEachConditionIsRan); i++)
            {
                // Finds the first child node that is empty
                if (ComparisonImageChosen.ChildNodes[i].InnerText == "")
                {
                    // Saves the subjects selections to the first empty node
                    XmlNode ComparisonImageChosenCondition = ComparisonImageChosen.ChildNodes[i];
                    ComparisonImageChosenCondition.InnerText = wasTheComparisonImageChosenString;

                    // Appends the date and time to the subjects selection
                    XmlElement dateTime = doc.CreateElement("Date-Time");
                    ComparisonImageChosenCondition.AppendChild(dateTime);
                    DateTime today = DateTime.Now;
                    dateTime.InnerText = today.ToString();

                    break;
                } // if
            } // for

            // Saves the xml document and stops playing the editor.
            doc.Save("subjects/" + subjectName + "/" + subjectName + ".xml");
            UnityEditor.EditorApplication.isPlaying = false;
        } // else
    } // Control
} // Main

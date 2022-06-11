using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class SceneChanger : MonoBehaviour
{
    // Creates variables
    public int numberOfSteroscopicImages;
    public int iteration;
    public bool wait;
    public int imageScene;
    public int waitingScene;
    public int[] userInput;
    public int[] comparisonImageOrder;

    // Called when game object with this script is initialized
    private void Awake()
    {
        // Stops game object with this script on it from being destoyed on load
        DontDestroyOnLoad(this.gameObject);

        // Initialzes variables
        numberOfSteroscopicImages = 330;
        iteration = 0;
        wait = true;
        imageScene = 1;
        waitingScene = 2;
        userInput = new int[1 + numberOfSteroscopicImages];
        comparisonImageOrder = new int[numberOfSteroscopicImages];

    } // Awake()

    // Displays the images on the image scene after a timer
    public IEnumerator DispImage(int iteration, int ranOrder, int j)
    {
        Texture2D leftTex;
        Texture2D rightTex;

        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene(imageScene);

        // Finds the standard and comparison images by the order specified by ranOrder
        if (ranOrder == 1)
        {
            // Finds the standard images
            // Finds the textures for the left and right images
            leftTex = (Texture2D)Resources.Load("Standard/Left/left-" + iteration.ToString(), typeof(Texture2D));
            rightTex = (Texture2D)Resources.Load("Standard/Right/right-" + iteration.ToString(), typeof(Texture2D));
            j--;
            ranOrder = 0;
        } // if
        else
        {
            // Finds the comparison image
            // Finds the textures for the left and right images
            leftTex = (Texture2D)Resources.Load("Comparison/Left/left-" + iteration.ToString(), typeof(Texture2D));
            rightTex = (Texture2D)Resources.Load("Comparison/Right/right-" + iteration.ToString(), typeof(Texture2D));
            j--;
            ranOrder = 1;
        } // else

        // waits for seconds
        yield return new WaitForSecondsRealtime(.5f);

        // Finds the left object and applies the left texture
        GameObject leftEyeImageDisp = GameObject.FindGameObjectWithTag("leftEyeImage");
        leftEyeImageDisp.GetComponent<Renderer>().material.mainTexture = leftTex;

        // Finds the right object and applies the right texture
        GameObject rightEyeImageDisp = GameObject.FindGameObjectWithTag("rightEyeImage");
        rightEyeImageDisp.gameObject.GetComponent<Renderer>().material.mainTexture = rightTex;

        StartCoroutine(WaitingScene(ranOrder, j));

    } // ChangeImageByTimer()

    // Changes scene to the pause in between displaying images
    public IEnumerator WaitingScene(int ranOrder, int j)
    {
        // Changes scene to the waiting scene after timer
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene(waitingScene);

        // Checks to see if both the comparison and standard image have been displayed
        // then displays the second image if it has not been displayed yet or waits
        // for the user input.
        if (j == 1)
        {
            StartCoroutine(DispImage(iteration, ranOrder, j));
        } // if
        else
        {
            StartCoroutine(WaitingForInput());
        } // else
           
    } // WaitingScene()

    // Waits for user input
    public IEnumerator WaitingForInput()
    {
        // Changes scene to the waiting scene after timer
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene(waitingScene);
        wait = true;
    } // WaitingForInput()


    // Called every frame
    public void Update()
    {
        // Checks if waiting on input, checks for input and then changes scene
        if (wait)
        {

            // Returns true if the button is pressed
            bool FirstImageChosen = Input.GetButtonDown("Fire2");
            bool secondImageChosen = Input.GetButtonDown("Jump");


            if (secondImageChosen | FirstImageChosen)
            {
                // Checks which button was pressed and writes it to userInput
                if (FirstImageChosen)
                {
                    userInput[iteration] = 0;
                } // if
                else
                {
                    userInput[iteration] = 1;
                } // else

                // Tells to stop waiting, and changes the scene
                wait = false;
                SceneManager.LoadScene(imageScene);
                Main();
            } // if
        } // if
    } // Update()


    // Finds random number
    // Either 0 or 1
    public int RandomNumber()
    {
        var rand = new System.Random();
        int ranNum= rand.Next(0,2);
        return ranNum;
    } // RandomNumber

    // Controls the iteration number for the amount of images diaplayed
    public void Main()
    {

        // Runs code until all the images are displayed then prints the user input as a txt file
        if (iteration < numberOfSteroscopicImages)
        {
            // ranOrder selects the order at which the comparison and standard images are displayed
            int ranOrder = RandomNumber();
            comparisonImageOrder[iteration] = ranOrder;

            iteration += 1;
            StartCoroutine(DispImage(iteration, ranOrder, 2));
        } // if
        else
        {
            // Saves user unput to a txt file
            string[] userInputStringArray = new string[numberOfSteroscopicImages];
            for (int i = 0; i < (numberOfSteroscopicImages); i++)
            {
                userInputStringArray[i] = userInput[i + 1].ToString();
            } // for
            File.WriteAllLines("userInput.txt", userInputStringArray);


            // Saves the comparison image order to a txt file
            string[] compOderStringArray = new string[numberOfSteroscopicImages];
            for (int i = 0; i < (numberOfSteroscopicImages); i++)
            {
                compOderStringArray[i] = comparisonImageOrder[i].ToString();
            } // for
            File.WriteAllLines("ComparisonImageOrder.txt", compOderStringArray);

        } // else
    } // Main()
} // SceneChanger

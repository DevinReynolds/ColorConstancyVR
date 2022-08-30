using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using System;
using System.IO;

public class Manage : MonoBehaviour
{
    // Creates Variables
    public int numberOfConditions;
    public int numberOfImagesDisplayedPerConditionPerLighness;
    public int numberOfImagesGeneratedPerConditionPerLighness;
    public int numberOfTimesEachConditionIsRan;
    public int numberOfLightnessValues;
    public string[] conditionNames;
    public string[] lightnessValueNames;

    public void createDirectory(string subjectName)
    {
        System.IO.Directory.CreateDirectory("subjects/" + subjectName);
        initialization();
        if (!File.Exists("subjects/" + subjectName + "/" + subjectName + ".xml"))
        {
            initializationBySubjectName(subjectName);
            runAquisition(subjectName);
        } 
        else
        {
            runAquisition(subjectName);
        }
    }

    // Initializes variables that are consistant throughout all test subjects for a given experiment.
    // This should be changed depending on the images that are generated.
    public void initialization()
    {
        // Change based on the experiment.
        numberOfConditions = 5;

        // Should be consistant thoughout all experiments.
        numberOfImagesDisplayedPerConditionPerLighness = 10;
        numberOfImagesGeneratedPerConditionPerLighness = 10;
        numberOfTimesEachConditionIsRan = 3;
        numberOfLightnessValues = 11;

        // Don't change these
        conditionNames = new string[numberOfConditions];
        lightnessValueNames = new string[numberOfLightnessValues];

        // Condition names.
        // These should be the exact name of the file directory of a given condition.
        conditionNames[0] = "Condition1";
        conditionNames[1] = "Condition2";
        conditionNames[2] = "Condition3";
        conditionNames[3] = "Condition4";
        conditionNames[4] = "Condition5";

        // Should be consistant thoughout all experiments.
        lightnessValueNames[0] = "3500";
        lightnessValueNames[1] = "3600";
        lightnessValueNames[2] = "3700";
        lightnessValueNames[3] = "3800";
        lightnessValueNames[4] = "3900";
        lightnessValueNames[5] = "4000";
        lightnessValueNames[6] = "4100";
        lightnessValueNames[7] = "4200";
        lightnessValueNames[8] = "4300";
        lightnessValueNames[9] = "4400";
        lightnessValueNames[10] = "4500";
    } // initialization

    // Initializes per subject information, i.e., order of the
    // conditions that will be presented each time a trial is ran, and
    // the order of the comparison images that will be displayed throughout each trial.
    //
    // An Xml document is used to store the imformation. 
    public void initializationBySubjectName(string subjectName)
    {
        // Sets up a new Xml document for a subject.
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement(subjectName);
        doc.AppendChild(root);
        XmlElement comparisonOrder = doc.CreateElement("ComparisonOrder");
        root.AppendChild(comparisonOrder);
        XmlElement standardOrder = doc.CreateElement("StandardOrder");
        root.AppendChild(standardOrder);
        XmlElement subjectAwnser = doc.CreateElement("ComparisonImageChosen");
        root.AppendChild(subjectAwnser);

        var random = new System.Random();

        // Runs for the number of times each condition is ran
        for (int l = 0; l < numberOfTimesEachConditionIsRan; l++)
        {
            // Randomizes the order of the conditions and the order that the comparision images are displayed.
            int[] conditionOrder = new int[numberOfConditions];
            int num1;
            for (int k = 0; k < numberOfConditions; k++)
            {
                num1 = random.Next(1, numberOfConditions + 1);
                if (!conditionOrder.Contains(num1))//If it's not contains, add number to array;
                {
                    // Set the order of the condition in the Xml document.
                    conditionOrder[k] = num1;
                    XmlElement conditionComparison = doc.CreateElement(conditionNames[num1 - 1]);
                    comparisonOrder.AppendChild(conditionComparison);
                    XmlElement conditionStandard = doc.CreateElement(conditionNames[num1 - 1]);
                    standardOrder.AppendChild(conditionStandard);
                    XmlElement conditionComparisonChosen = doc.CreateElement(conditionNames[num1 - 1]);
                    subjectAwnser.AppendChild(conditionComparisonChosen);

                    // Randomly add numbers to imageOrder[] without repeating them.
                    //
                    // imageOrder[] is a random array that determines which order the lightnessValueNames[]
                    // are presented for numberOfImagesDisplayedPerConditionPerLighness number of 
                    // individual lightnessValueNames[].
                    int num2;
                    int occurrences;
                    int[] imageOrderTemp = new int[numberOfLightnessValues * numberOfImagesDisplayedPerConditionPerLighness];
                    int[] imageOrder = new int[numberOfLightnessValues * numberOfImagesDisplayedPerConditionPerLighness];
                    for (int i = 0; i < (numberOfLightnessValues * numberOfImagesDisplayedPerConditionPerLighness); i++)
                    {
                        num2 = random.Next(1, numberOfLightnessValues + 1);
                        occurrences = imageOrderTemp.Count(x => x == num2);
                        if (!(occurrences == numberOfImagesDisplayedPerConditionPerLighness)) // If the number is unique, add it to the array
                        {
                            imageOrderTemp[i] = num2;
                            imageOrder[i] = num2 - 1;
                        } // if
                        else // Restart random process
                        {
                            i--;
                        } // else
                    } // for

                    // Randomly add numbers to imageOrderPerReflectance[,] without repeating them.
                    //
                    // imageOrderPerReflectance[,] is a random array that determines the order that 
                    // which the specific images amongst the larger library of images are chosen.
                    //
                    // A multidimensional array is used. It is of the form Image Number by lightness value.
                    int num3;
                    int[,] imageOrderPerLightness = new int[numberOfImagesDisplayedPerConditionPerLighness, numberOfLightnessValues];
                    for (int j = 0; j < numberOfLightnessValues; j++)
                    {
                        int[] imageOrderPerReflectanceTemp = new int[numberOfImagesDisplayedPerConditionPerLighness];
                        for (int i = 0; i < numberOfImagesDisplayedPerConditionPerLighness; i++)
                        {
                            num3 = random.Next(1, numberOfImagesGeneratedPerConditionPerLighness + 1);
                            if (!imageOrderPerReflectanceTemp.Contains(num3)) // If the number is unique, add it to the array
                            {
                                imageOrderPerReflectanceTemp[i] = num3;
                                imageOrderPerLightness[i, j] = num3;
                            } // if
                            else // Restart random process
                            {
                                i--;
                            } // else
                        } // for
                    } // for

                    // Turns imageOrder[] and imageOrderPerReflectance[,] into a single string
                    // of the form "lightnessValueName-imageNumber-lightnessValueName-imageNumber-..."
                    string imageOrderString = "";
                    for (int j = 0; j < (numberOfLightnessValues * numberOfImagesDisplayedPerConditionPerLighness); j++)
                    {
                        for (int i = 0; i < numberOfImagesDisplayedPerConditionPerLighness; i++)
                        {
                            if (!(imageOrderPerLightness[i, imageOrder[j]] == 0))
                            {
                                imageOrderString += lightnessValueNames[imageOrder[j]] + "|" + imageOrderPerLightness[i, imageOrder[j]].ToString() + "|";
                                imageOrderPerLightness[i, imageOrder[j]] = 0; // Sets to 0 and skips 0 as it easily aligns the order of the two arrays.
                                break;
                            } // for
                        } // for
                    } // for

                    // Set the order of a specific condition in the Xml document.
                    conditionComparison.InnerText = imageOrderString;

                    // Selects images of lightness 0.4500 at random.
                    // Comparison image will be compared to these random images.
                    string standardImageOrder = "";
                    for (int i = 0; i < (numberOfLightnessValues * numberOfImagesDisplayedPerConditionPerLighness); i++)
                    {
                        standardImageOrder += random.Next(1, numberOfImagesGeneratedPerConditionPerLighness + 1).ToString() + "|";
                    } // for
                    conditionStandard.InnerText = standardImageOrder;
                } // if
                else //If it contains, restart random process
                {
                    k--;
                } // else
            } // for
        } // for       

        // Saves the Xml document
        doc.Save("subjects/" + subjectName + "/" + subjectName + ".xml");
    } // initializationBySubjectName

    // Reads the subjects xml file and starts the aquisition.
    public void runAquisition(string subjectName)
    {
        // Loads the xml and sets nodes
        XmlDocument doc = new XmlDocument();
        doc.Load("subjects/" + subjectName + "/" + subjectName + ".xml");
        XmlNode root = doc.FirstChild;
        XmlNode comparisonOrder = root.ChildNodes[0];
        XmlNode standardOrder = root.ChildNodes[1];
        XmlNode ComparisonImageChosen = root.ChildNodes[2];

        // Finds the first condition that has not been ran as 
        // saves the name and the comparison image order as 
        // a string.
        string comparisonImageOrder = "";
        string standardImageOrder = "";
        string conditionName = "";       
        for (int i = 0; i < (numberOfConditions * numberOfTimesEachConditionIsRan); i++)
        {
            if (ComparisonImageChosen.ChildNodes[i].InnerText == "")
            {
                XmlNode conditionComparison = comparisonOrder.ChildNodes[i];
                XmlNode conditionStandard = standardOrder.ChildNodes[i];
                comparisonImageOrder = conditionComparison.InnerText;
                standardImageOrder = conditionStandard.InnerText;
                conditionName = conditionComparison.Name;
                
                // Finds and runs the StartAquisition method on the Main script
                GameObject ScriptObject = GameObject.FindGameObjectWithTag("Scripts");
                ScriptObject.GetComponent<Main>().StartAquisition(subjectName, conditionName, comparisonImageOrder, numberOfConditions, numberOfTimesEachConditionIsRan, standardImageOrder);

                break;
            } // if
            if (i == ((numberOfConditions * numberOfTimesEachConditionIsRan) - 1)) // Doens't run a condition if all conditions have already been ran
            {
                Debug.LogError("All conditions have been ran");
                UnityEditor.EditorApplication.isPlaying = false;
            } // if
        } // for
    } // runAquisition
} // Manage
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class runAquisitionBySubjectName : EditorWindow
{
    [MenuItem("Start/Run Aquisition")]
    static void Init()
    {
        runAquisitionBySubjectName window = ScriptableObject.CreateInstance<runAquisitionBySubjectName>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    } // Init

    string subjectName = "";
    void OnGUI()
    {
        EditorGUILayout.LabelField("Enter the subjects name", EditorStyles.wordWrappedLabel);
        subjectName = GUILayout.TextField(subjectName, 25);
        GUILayout.Space(70);
        if (GUILayout.Button("Start"))
        {
            // Starts playing the unity editor
            UnityEditor.EditorApplication.isPlaying = true;

            // Finds as runs the createDirectory method in the Manage script
            GameObject ScriptObject = GameObject.FindGameObjectWithTag("Scripts");
            ScriptObject.GetComponent<Manage>().createDirectory(subjectName);

            // Closes the popup
            this.Close();
        } // if
    } // OnGui
} // runAquisitionBySubjectName

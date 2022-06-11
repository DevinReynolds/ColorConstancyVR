using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{

    // Time to be count down
    public float timeCountdown = 10.0f;

    // Update is a method called every frame
    void Update()
    {

        // Subtracts elapsed time from timeCountdown
        timeCountdown -= Time.deltaTime;

        // Checks if timer is <= 0
        if (timeCountdown <= 0.0f)
        {

            // Changes scene
            SceneManager.LoadScene(0);
            
        } // if

    } // update

} // sceneChange

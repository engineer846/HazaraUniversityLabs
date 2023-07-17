using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Image Filler;
    public Text LoadingProgress;
    // Start is called before the first frame update
    void Start()
    {
        Filler.fillAmount = 0;
        //Invoke("LoadScene", 2);
        StartCoroutine(LoadScene());
    }


    //void LoadScene()
    //{
    //    SceneManager.LoadSceneAsync(1);
    //}

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            LoadingProgress.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            Filler.fillAmount = asyncOperation.progress;
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                LoadingProgress.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

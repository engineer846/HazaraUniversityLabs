using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform SpawnPoint;
    public BallController ballController;

    public List<GameObject> BallsList = new List<GameObject>();
    public GameObject[] Balls;

    public GameObject PausePanel;
    public GameObject GamePlayPanel;
    public GameObject WinPanel;
    public GameObject FailPanel;

    public Image Filler;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //Filler.fillAmount = 1;
        //Filler.color = Color.blue;
        //InvokeRepeating("TestInvoke", 2, 1);
        //StartCoroutine(TestCoroutine());
    }

    //private void Update()
    //{
    //    if(Filler.fillAmount > 0)
    //    {
    //        Filler.fillAmount -= 0.1f * Time.deltaTime;
    //        if(Filler.fillAmount >= 0.3f)
    //        {
    //            Filler.color = Color.blue;
    //        }
    //        else
    //        {
    //            Filler.color = Color.red;
    //        }
    //    }
    //}

    //void TestInvoke()
    //{
    //    Debug.Log("Printing Invoke");
    //}
    //IEnumerator TestCoroutine()
    //{
    //    yield return new WaitForSeconds(1);
    //    Filler.fillAmount += 0.1f;
    //    if(Filler.fillAmount < 1)
    //    {
    //        StartCoroutine(TestCoroutine());
    //    }

    //}


    public void Resume()
    {
        Debug.Log("Resume button is clicked");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int ColorIndex = 0;
    public Transform SpawnPoint;
    //bool CheckCollision = false;

    //private void OnCollisionEnter(Collision Other)
    //{
        //if (Other.collider.gameObject.tag == "Slope" && this.gameObject.tag == "Ball")
        //{
        //    //CheckCollision = true;
        //    SpawnPoint = GameManager.instance.SpawnPoint;
        //    GameObject BallPrefab = GameManager.instance.Balls[Random.Range(0,3)];
        //    GameObject Go = Instantiate(BallPrefab, SpawnPoint); Go.transform.localPosition = new Vector3(0, 0, 0);
        //    GameManager.instance.BallsList.Add(Go);
        //    //Go.name = "Ball";
        //    if(Go.GetComponent<BallController>().ColorIndex == 3)
        //    {
        //        GameManager.instance.BallsList.Remove(Go);
        //        Destroy(Go.gameObject);
        //    }
        //    //this.GetComponent<BallController>().enabled = false;
        //}

        //if (Other.gameObject.tag.Contains("Ground"))
        //{
        //    GameManager.instance.BallsList.Remove(this.gameObject);
        //    Destroy(this.gameObject);
        //}
       
    //}

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Hurdle" && this.gameObject.tag == "Ball")
        {
            //CheckCollision = true;
            SpawnPoint = GameManager.instance.SpawnPoint;
            GameObject BallPrefab = GameManager.instance.Balls[Random.Range(0, 3)];
            GameObject Go = Instantiate(BallPrefab, SpawnPoint); Go.transform.localPosition = new Vector3(0, 0, 0);
            GameManager.instance.BallsList.Add(Go);
            //Go.name = "Ball";
            if (Go.GetComponent<BallController>().ColorIndex == 3)
            {
                GameManager.instance.BallsList.Remove(Go);
                //Destroy(Go.gameObject);
            }
            //this.GetComponent<BallController>().enabled = false;
        }

        if (Other.gameObject.tag.Contains("Ground"))
        {
            GameManager.instance.BallsList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}

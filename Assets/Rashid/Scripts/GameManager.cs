using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform SpawnPoint;
    public BallController ballController;

    public GameObject[] Balls;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}

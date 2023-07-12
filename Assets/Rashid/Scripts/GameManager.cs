using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform SpawnPoint;
    public GameObject[] Balls;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}

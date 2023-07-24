using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    //public Material[] Materials;
    public OpponentProperties opponentProps;
    private void OnEnable()
    {
        this.GetComponent<Renderer>().material = opponentProps.Materials[Random.Range(0, opponentProps.Materials.Length)];
    }
}

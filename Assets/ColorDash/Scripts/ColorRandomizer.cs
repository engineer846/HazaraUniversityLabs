using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public Material[] Materials;
    private void OnEnable()
    {
        this.GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];
    }
}

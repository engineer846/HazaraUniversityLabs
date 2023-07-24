using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OpponentProperties", menuName = "ScriptableObjects/OpponentProperties", order = 1)]
public class OpponentProperties : ScriptableObject
{
    public int ColorIndex = 0;
    public Material[] Materials;
}

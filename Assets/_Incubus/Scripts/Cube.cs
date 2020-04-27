using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName ="Cube",menuName ="Incubus/Cubes/Cube")]
public class Cube:ScriptableObject
{
    public int CubeNumber;
    public Material Texture;
    public GameObject Puzzle_Prefab;

    [Header("Surrounds")]
    public Cube N_Cube;
    public Cube S_Cube;
    public Cube E_Cube;
    public Cube W_Cube;

    //public puzzle Puzzle
}

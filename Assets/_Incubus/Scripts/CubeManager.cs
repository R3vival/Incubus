using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="CubeManager",menuName ="Incubus/Cubes/CubeManager")]
public class CubeManager : ScriptableObject
{
    public Cube CurrentCube;

    public Cube[] Cubes;
}

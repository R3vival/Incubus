using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubusGameController : MonoBehaviour
{
    public GameObject[] Cubes;
    
    GameManager gameManager;
    [Header("Cubo null")]
    public Material NullCube;

    private void Awake()
    {
        gameManager = GameManager.instance;
        gameManager.CubeManager.CurrentCube = GameManager.instance.CubeManager.Cubes[0];
    }

    private void Start()
    {
        //SetUpRooms();
    }


    //private void SetUpRooms()
    //{
    //    if (Cubes != null)
    //        for(int i =0; i< Cubes.Length; i++)
    //            switch (i)
    //            {
    //                case 0:
    //                    Cubes[i].GetComponent<MeshRenderer>().material = gameManager.CubeManager.CurrentCube.Texture;
    //                    break;
    //                case 1:
    //                    if (gameManager.CubeManager.CurrentCube.N_Cube)
    //                        Cubes[i].GetComponent<MeshRenderer>().material = gameManager.CubeManager.CurrentCube.N_Cube.Texture;
    //                    else
    //                        Cubes[i].GetComponent<MeshRenderer>().material = NullCube;
    //                    break;
    //                case 2:
    //                    if (gameManager.CubeManager.CurrentCube.S_Cube)
    //                        Cubes[i].GetComponent<MeshRenderer>().material = gameManager.CubeManager.CurrentCube.S_Cube.Texture;
    //                    else
    //                        Cubes[i].GetComponent<MeshRenderer>().material = NullCube;
    //                    break;
    //                case 3:
    //                    if (gameManager.CubeManager.CurrentCube.E_Cube)
    //                        Cubes[i].GetComponent<MeshRenderer>().material = gameManager.CubeManager.CurrentCube.E_Cube.Texture;
    //                    else
    //                        Cubes[i].GetComponent<MeshRenderer>().material = NullCube;
    //                    break;
    //                case 4:
    //                    if (gameManager.CubeManager.CurrentCube.W_Cube)
    //                        Cubes[i].GetComponent<MeshRenderer>().material = gameManager.CubeManager.CurrentCube.W_Cube.Texture;
    //                    else
    //                        Cubes[i].GetComponent<MeshRenderer>().material = NullCube;
    //                    break;
    //            }
                
    //}

    public void ChangeCube(string CubeOrientation)
    {
        switch (CubeOrientation)
        {
            case "N_Cube":
                gameManager.CubeManager.CurrentCube = gameManager.CubeManager.CurrentCube.N_Cube;
                break;
            case "S_Cube":
                gameManager.CubeManager.CurrentCube = gameManager.CubeManager.CurrentCube.S_Cube;
                break;
            case "E_Cube":
                gameManager.CubeManager.CurrentCube = gameManager.CubeManager.CurrentCube.E_Cube;
                break;
            case "W_Cube":
                gameManager.CubeManager.CurrentCube = gameManager.CubeManager.CurrentCube.W_Cube;
                break;
        }
        //SetUpRooms();
    }
}

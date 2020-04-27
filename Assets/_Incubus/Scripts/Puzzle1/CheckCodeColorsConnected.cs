using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCodeColorsConnected : MonoBehaviour
{
    ColorsConnecController colorsConnecController;
    public GameObject puzzle;
    public CodeController codeController;
    public MeshRenderer[] doorToUnlock;
    public Material openedDoor;
    public Door[] door;
    public SoundsController soundsController;
    private void Awake()
    {
        colorsConnecController = GetComponent<ColorsConnecController>();
        foreach (MeshRenderer mesh in doorToUnlock)
            mesh.sharedMaterials[1].color = Color.red;
    }
   
    public void CheckCode()
    {
        if (colorsConnecController.currentCodes[0] == colorsConnecController.trueCodeColorsConnect[0] && 
            colorsConnecController.currentCodes[1] == colorsConnecController.trueCodeColorsConnect[1] && 
            colorsConnecController.currentCodes[2] == colorsConnecController.trueCodeColorsConnect[2] && 
            colorsConnecController.currentCodes[3] == colorsConnecController.trueCodeColorsConnect[3] && 
            colorsConnecController.currentCodes[4] == colorsConnecController.trueCodeColorsConnect[4] && 
            colorsConnecController.currentCodes[5] == colorsConnecController.trueCodeColorsConnect[5] && 
            colorsConnecController.currentCodes[6] == colorsConnecController.trueCodeColorsConnect[6] && 
            colorsConnecController.currentCodes[7] == colorsConnecController.trueCodeColorsConnect[7] && 
            colorsConnecController.currentCodes[8] == colorsConnecController.trueCodeColorsConnect[8] && 
            colorsConnecController.currentCodes[9] == colorsConnecController.trueCodeColorsConnect[9])
                {
                    StartCoroutine(UnlockDoorPuzzle());
                }
        else
            return;
              
    }

    IEnumerator UnlockDoorPuzzle()
    {
        soundsController.PlayPuzzleUnlockedSound();
        yield return new WaitForSeconds(0.5f);
        foreach(MeshRenderer mesh in doorToUnlock)
        {
            mesh.materials[1].CopyPropertiesFromMaterial(openedDoor);
        }
        foreach(Door _door in door)
            _door.Closed = false;

        yield return new WaitForSeconds(1.5f);
        codeController.SetCodeUnlocked(0,1);
        codeController.CodeChecker();
        puzzle.SetActive(false);
    }
}

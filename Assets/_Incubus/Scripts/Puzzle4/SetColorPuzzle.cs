using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadyToBePressed))]
public class SetColorPuzzle : MonoBehaviour
{
    public int ID = 0;
    public PuzzleColorsController puzzleColorsController;
    public bool Pressed = false;
    public Light myLight;
    ReadyToBePressed readyToBePressed;
    GameObject puzzleCube;
    public CodeController codeController;
    public MeshRenderer[] doorToUnlock;
    public Material openedDoor;
    public Door[] door;
    private void Start()
    {
        myLight = GetComponentInChildren<Light>();
        readyToBePressed = GetComponent<ReadyToBePressed>();
        puzzleCube = transform.parent.gameObject;
    }
    private void Update()
    {
        if(readyToBePressed.IAmReadyToBePressed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                if (!Pressed)
                {
                    if(puzzleColorsController.currentCode < 3)
                    {
                        puzzleColorsController.SetColor(ID);
                        myLight.enabled = true;
                        Pressed = true;
                    }
                    else
                    {
                        StartCoroutine(checkPuzzle());
                    }
                }
            }
        }
    }
    private IEnumerator checkPuzzle()
    {
        puzzleColorsController.SetColor(ID);
        puzzleColorsController.CheckPuzzleColors();

        if(puzzleColorsController.madePuzzle)
        {
            myLight.enabled = true;
            yield return new WaitForSeconds(1.5f);
            foreach (MeshRenderer mesh in doorToUnlock)
            {
                mesh.materials[1].CopyPropertiesFromMaterial(openedDoor);
            }
            foreach (Door _door in door)
                _door.Closed = false;
            codeController.SetCodeUnlocked(3, 5);
            codeController.CodeChecker();
            puzzleCube.SetActive(false);
        }
        else
        {
            Pressed = true;
            myLight.enabled = true;
            yield return new WaitForSeconds(3);
            myLight.enabled = false;
            Pressed = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSameTimeController : MonoBehaviour
{
    public float milisecondsLimit = 100.0f;
    public float currentMiliseconds = 0.0f;
    public bool isWinning;
    public bool running = false;
    public SliderMovement[] sliderMovements;
    public int goalReached = 0;
    public CodeController codeController;
    public MeshRenderer[] doorToUnlock;
    public Material openedDoor;
    public Door[] door;
    public SoundsController soundsController;
    private void Start()
    {
        sliderMovements = GetComponentsInChildren<SliderMovement>();
    }
    public void CallTimer()
    {
        StartCoroutine(timer());
    }
    private IEnumerator timer()
    {
        while(currentMiliseconds<=milisecondsLimit)
        {
            yield return new WaitForSeconds(0.01f);
            currentMiliseconds++;
            isWinning = true;
            if(currentMiliseconds>= milisecondsLimit)
            {
                isWinning = false;
            }
            
        }
    }
    
    IEnumerator UnlockDoor()
    {
        soundsController.PlayPuzzleUnlockedSound();
        yield return new WaitForSeconds(0.5f);
        codeController.SetCodeUnlocked(2, 2);
        foreach (MeshRenderer mesh in doorToUnlock)
        {
            mesh.materials[1].CopyPropertiesFromMaterial(openedDoor);
        }
        foreach (Door _door in door)
            _door.Closed = false;

        codeController.CodeChecker();
        gameObject.SetActive(false);
    }
    public void CheckPuzzle()
    {
        if (goalReached >= 3)
        {
            if (isWinning)
            {
                StartCoroutine(UnlockDoor());
            }
            else
            {
                running = false;
                goalReached = 0;
                currentMiliseconds = 0;
                foreach(SliderMovement sliders in sliderMovements)
                {
                    sliders.gameObject.transform.position = sliders.startPos;
                    sliders.currentLerpTime = 0;
                    soundsController.PlayWrongSound();
                }
            }

        }
        else
            return;

    }
}

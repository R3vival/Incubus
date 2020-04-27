using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColorsController : MonoBehaviour
{
    public int[] trueCodes = new int[4];
    public int[] Codes = new int[4];
    public int currentCode = 0;
    public SetColorPuzzle[] setColorPuzzles =new SetColorPuzzle[4];
    public bool madePuzzle = false;
    public SoundsController soundsController;
    public void CheckPuzzleColors()
    {
        if(Codes[0]==trueCodes[0] && Codes[1] == trueCodes[1] && Codes[2] == trueCodes[2] && Codes[3] == trueCodes[3])
        {
            soundsController.PlayPuzzleUnlockedSound();
            madePuzzle = true;
        }
        else
        {
            soundsController.PlayWrongSound();
            ResetPuzzle();
        }
    }

    public void ResetPuzzle()
    {
        currentCode = 0;
        foreach(SetColorPuzzle _setColorPuzzle in setColorPuzzles)
        {
            _setColorPuzzle.Pressed = false;
            _setColorPuzzle.myLight.enabled = false;
        }
    }

    public void SetColor(int ID)
    {
        if(currentCode<3)
        {
            Codes[currentCode] = ID;
            currentCode++;
                
        }
        else
        {
            Codes[currentCode] = ID;
            currentCode++;
        }

    }
}

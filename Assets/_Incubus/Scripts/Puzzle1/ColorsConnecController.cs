using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsConnecController : MonoBehaviour
{
    public bool drawingRed, drawingBlue, drawingYellow;
    public int[] trueCodeColorsConnect = new int[10];
    public int[] currentCodes = new int[10];

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)))
        {
            drawingRed = false;
            drawingYellow = false;
            drawingBlue = false;
        }
    }
    
}

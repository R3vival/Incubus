using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadyToBePressed))]
public class ConnectColors : MonoBehaviour
{
    public enum _Color { Blue, Red, Yellow, _null}
    public _Color myColor;
    public MeshRenderer meshRenderer;
    public Material defaultMaterial, redMaterial, blueMaterial, yellowMaterial;
    public ColorsConnecController colorsConnecController;
    public int IDCube;
    ReadyToBePressed readyToBePressed;
    public CheckCodeColorsConnected checkCode;
    private void Awake()
    {
        readyToBePressed = GetComponent<ReadyToBePressed>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void Reset()
    {
        meshRenderer.enabled = false;
    }

    void Update()
    {
        if(readyToBePressed.IAmReadyToBePressed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                switch (myColor)
                {
                    case _Color.Blue:
                        {
                            colorsConnecController.drawingBlue = true;
                            colorsConnecController.drawingRed = false;
                            colorsConnecController.drawingYellow = false;
                            break;
                        }
                    case _Color.Red:
                        {
                            colorsConnecController.drawingBlue = false;
                            colorsConnecController.drawingRed = true;
                            colorsConnecController.drawingYellow = false;
                            break;
                        }
                    case _Color.Yellow:
                        {
                            colorsConnecController.drawingBlue = false;
                            colorsConnecController.drawingRed = false;
                            colorsConnecController.drawingYellow = true;
                            break;
                        }
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (colorsConnecController.drawingBlue)
                {
                    switch (myColor)
                    {
                        case _Color._null:
                            {
                                if (meshRenderer != null)
                                {
                                    meshRenderer.enabled = true;
                                    meshRenderer.material = blueMaterial;
                                    colorsConnecController.currentCodes[IDCube] = 1;
                                    checkCode.CheckCode();
                                }
                                else
                                    return;
                                break;
                            }
                    }
                }
                else if (colorsConnecController.drawingRed)
                {
                    switch (myColor)
                    {
                        case _Color._null:
                            {
                                if (meshRenderer != null)
                                {
                                    meshRenderer.enabled = true;
                                    meshRenderer.material = redMaterial;
                                    colorsConnecController.currentCodes[IDCube] = 2;
                                    checkCode.CheckCode();
                                }
                                else
                                    return;
                                break;
                            }
                    }
                }
                else if (colorsConnecController.drawingYellow)
                {
                    switch (myColor)
                    {
                        case _Color._null:
                            {
                                if (meshRenderer != null)
                                {
                                    meshRenderer.enabled = true;
                                    meshRenderer.material = yellowMaterial;
                                    colorsConnecController.currentCodes[IDCube] = 3;
                                    checkCode.CheckCode();
                                }
                                else
                                    return;
                                break;
                            }
                    }
                }
            }
        } 
    }
}

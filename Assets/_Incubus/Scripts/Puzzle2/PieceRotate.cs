using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadyToBePressed))]
public class PieceRotate : MonoBehaviour
{
    ReadyToBePressed readyToBePressed;
    public Transform myParent;
    public float anglesToRotate;
    private void Start()
    {
        readyToBePressed = GetComponent<ReadyToBePressed>();
        myParent = gameObject.transform.parent;
    }
    private void Update()
    {
        if (readyToBePressed.IAmReadyToBePressed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                myParent.Rotate(0f, 0f, anglesToRotate);
            }
        }
    }

}

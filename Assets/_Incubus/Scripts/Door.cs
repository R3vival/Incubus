using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorOrientation Orientation;
    public bool Closed;

    Animator DoorAnimator;

    [Header("NextRoom")]
    public Transform NextRoomWayPoint;
    public Door NextRoomDoor;
    public ReadyToBePressed PressController;

    IncubusPlayerController IncubusPlayercontroller;
    public SoundsController soundsController;
    #region Unity Functions


    private void Awake()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
        IncubusPlayercontroller = GameObject.Find("OVRCameraRig").GetComponent<IncubusPlayerController>();
    }

    void Update()
    {
        if (PressController.IAmReadyToBePressed)
        {
            GlowingDoor();

            if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                OpenDoor();                
            }
        }
    }
    #endregion

    public void OpenDoor()
    {
        if (!Closed)
        {
            NextRoomDoor.DoorAnimator.SetInteger("DoorIndex", (int)NextRoomDoor.Orientation);
            DoorAnimator.SetInteger("DoorIndex", (int)Orientation);
            soundsController.PlayOpenDoorSound();
            StartCoroutine(MovePlayer());
        }
        
    }
    public void GlowingDoor()
    {
        //DoorAnimator.SetTrigger("Glow");
    }
    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(1f);        
        IncubusPlayercontroller.MoveToNextWayPoint(NextRoomWayPoint.position);
    }
}
public enum DoorOrientation
{
    North,
    East,
    South,
    West
}

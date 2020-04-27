using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadyToBePressed))]
public class SliderMovement : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Vector3 startPos;
    public float offsetY;
    public float lerpTime = 30;
    public float currentLerpTime = 0;
    public bool keyHit = false;
    private PuzzleSameTimeController puzzleSame;

    ReadyToBePressed readyToBePressed;
    private void Start()
    {
        startPos = transform.position;
        readyToBePressed = GetComponent<ReadyToBePressed>();
        puzzleSame = GetComponentInParent<PuzzleSameTimeController>();
    }
    void Update()
    {
        if (readyToBePressed.IAmReadyToBePressed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                if(keyHit==false)
                {
                    puzzleSame.running = true;
                    StartCoroutine(slide());   
                }
                
            }
        }     
    }
    private IEnumerator slide()
    {
        keyHit = true;
        while(keyHit && puzzleSame.running)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                StopCoroutine(slide());
                keyHit = false;
                if(puzzleSame.goalReached<3)
                {
                    puzzleSame.goalReached++;
                } 
            }
            float Perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, new Vector3(target.position.x,target.position.y -offsetY,target.position.z), Perc);
            puzzleSame.CheckPuzzle();
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        puzzleSame.CallTimer();
    }
}

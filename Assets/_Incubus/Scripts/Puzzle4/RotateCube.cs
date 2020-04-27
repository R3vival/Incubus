using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadyToBePressed))]
public class RotateCube : MonoBehaviour
{
    public GameObject cube;
    public Transform target;
    public float lerpTime = 1.5f;
    public float currentLerpTime = 0;
    public bool keyHit = false;
    ReadyToBePressed readyToBePressed;
    private void Start()
    {
        readyToBePressed = GetComponent<ReadyToBePressed>();
    }
    void Update()
    {
        if (readyToBePressed.IAmReadyToBePressed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                if (keyHit == false)
                {
                    StartCoroutine(slide());
                }
            }
        }
    }
    private IEnumerator slide()
    {
        keyHit = true;
        while (keyHit )
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                keyHit = false;
                currentLerpTime = 0;
            }
            float Perc = currentLerpTime / lerpTime;
            cube.transform.rotation = Quaternion.Lerp(cube.transform.rotation, target.rotation, Perc);
            yield return null;
        }
    }
}

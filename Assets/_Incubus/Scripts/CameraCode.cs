using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCode : MonoBehaviour
{
    public RawImage raw;
    public Camera webCam;

    private void Start()
    {
        raw.texture = webCam.targetTexture;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{

    public Pointer m_Pointer;
    public SpriteRenderer m_CircleRenderer;
   
    public Sprite m_OpenSprite;
    public Sprite m_ClosedSprite;

    private Camera m_Camera = null;
    public GameObject currentTarget;

    private void Awake()
    {
        m_Pointer.OnPointerUpdate += UpdateSprite;

        m_Camera = Camera.main;
    }
    
    private void OnDestroy()
    {
        m_Pointer.OnPointerUpdate -= UpdateSprite;
    }

    
    void Update()
    {
        transform.LookAt(m_Camera.gameObject.transform);
    }

    private void UpdateSprite(Vector3 point, GameObject hitObject)
    {
        transform.position = point;
        if (hitObject)
        {
            if(currentTarget!=null)
            {
                if (currentTarget.GetComponent<ReadyToBePressed>() != null)
                    currentTarget.GetComponent<ReadyToBePressed>().IAmReadyToBePressed = false;
            }
            m_CircleRenderer.sprite = m_ClosedSprite;
            if(hitObject.GetComponent<ReadyToBePressed>()!=null)
            {
                hitObject.GetComponent<ReadyToBePressed>().IAmReadyToBePressed = true;

            }
            currentTarget = hitObject;
        }
            
        else
        {
            m_CircleRenderer.sprite = m_OpenSprite;
            if (currentTarget != null)
            {
                if (currentTarget.GetComponent<ReadyToBePressed>()!=null)
                    currentTarget.GetComponent<ReadyToBePressed>().IAmReadyToBePressed = false;
            }
        }  
    }
}

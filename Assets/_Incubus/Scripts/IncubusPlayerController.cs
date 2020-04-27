using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubusPlayerController : MonoBehaviour
{
    public float moveSpeed=0;

    bool move;
    Vector3 NextWayPoint, direction;
    float distance = 2f;
    


    public void MoveToNextWayPoint(Vector3 WayPoint)
    {
        NextWayPoint = WayPoint;
        Debug.Log(WayPoint);
                
        move = true;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            direction = NextWayPoint - transform.position;
            if (direction.magnitude < distance)
            {
                move = false;
            }
            Vector3 dir = direction.normalized;            
            GetComponent<Rigidbody>().velocity = new Vector3(dir.x * moveSpeed, dir.y * moveSpeed, dir.z*moveSpeed);
        }    
        if(!move)
            GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
}

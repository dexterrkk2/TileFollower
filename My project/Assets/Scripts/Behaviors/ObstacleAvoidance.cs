using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    float lookAhead = 60f;
    float avoidDistance = 100f;
    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;
        if(Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookAhead))
        {
            Debug.DrawRay(  character.transform.position, hit.point);
            if(hit.collider.tag == "Player")
            {
                return Vector3.zero;
            }
            return hit.point + (hit.normal * avoidDistance);
        }
        else
        {
           return Vector3.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering : Seek
{
    public List<BlendedSteering> groups;
    float minAcceleration = Mathf.Epsilon;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        for(int i =0; i<groups.Count; i++)
        {
            result.linear = groups[i].getSteering().linear;
            result.angular = groups[i].getSteering().angular;
            if(result.linear.magnitude > minAcceleration || Mathf.Abs(result.angular) > minAcceleration)
            {
                return result;
            }
        }
        return result;
    }
}

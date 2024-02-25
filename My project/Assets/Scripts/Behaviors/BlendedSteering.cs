using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendedSteering : Seek
{
    public List<BehaviourandWeight> behaviours;
    public float maxAcceleration;
    public float maxRotation;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        foreach(BehaviourandWeight b in behaviours)
        {
            result.linear += b.weight * b.Behavior.getSteering().linear;
            result.angular += b.weight * b.Behavior.getSteering().angular;
        }
        float maxClamp = Mathf.Max(result.linear.magnitude, maxAcceleration);
        result.linear.Normalize();
        result.linear *= maxClamp;
        result.angular = Mathf.Max(result.angular, maxRotation);
        return result;
    }
}

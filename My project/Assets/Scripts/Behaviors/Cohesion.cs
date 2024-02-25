using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : SteeringBehavior
{
    public Kinematic character;
    float maxAcceleration = 1f;

    public List<Kinematic> targets;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 sumPositions = Vector3.zero;
        foreach(Kinematic target in targets)
        {
            sumPositions += target.transform.position;
        }
        Vector3 average = sumPositions / targets.Count;
        Vector3 direction = average - character.transform.position;
        direction.Normalize();
        result.linear = direction *maxAcceleration;
        return result;
    }
}

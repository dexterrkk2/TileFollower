using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacleConstraint : Constraint
{
    Vector3 center;
    float radius;
    float margin;
    int problemIndex;
    public bool willViolate(List<GameObject> path, Goal goal)
    {
        for (int i=0; i<path.Count; i++)
        {
            Vector3 segment = path[i].transform.position;
            if(Vector3.Dot(segment, center) > radius)
            {
                problemIndex = i;
                return true;
            }
        }
        return false;
    }
    public Goal suggest(Kinematic character, List<GameObject> path, Goal goal)
    {
        Vector3 segment = path[problemIndex].transform.position;
        Vector3 middle = Vector3.Lerp(center, segment, .5f);
        Vector3 newPosition;
        if(middle.magnitude == 0)
        {
            Vector3 direction = segment - middle;
            Vector3 newDirection = Vector3.Reflect(direction, segment);
            newPosition = center + newDirection * radius * margin;
        }
        else
        {
            Vector3 offset = middle - center;
            newPosition = center + offset * radius * margin;
        }
        goal.position = newPosition;
        goal.hasPosition = true;
        return goal;
    }
}

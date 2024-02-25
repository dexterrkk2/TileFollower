using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Actuator
{
    List<GameObject> getPath(Kinematic character, Goal goal);
    SteeringOutput output(Kinematic character, List<GameObject> path, Goal goal);
}

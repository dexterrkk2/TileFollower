using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Constraint
{
    bool willViolate(List<GameObject>path, Goal goal);
    Goal suggest(Kinematic character, List<GameObject> path, Goal goal);
}

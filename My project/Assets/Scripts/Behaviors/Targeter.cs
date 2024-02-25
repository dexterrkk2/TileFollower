using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Targeter
{
    Goal getGoal(Kinematic character);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Decomposer 
{
    Goal decompose(Kinematic character, Goal goal);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTargeter : Targeter
{
    public Kinematic chasedCharacter;
    float lookAhead;
    public Goal getGoal(Kinematic character)
    {
        Goal goal = new Goal();
        goal.position = chasedCharacter.transform.position + chasedCharacter.linearVelocity *lookAhead;
        goal.hasPosition = true;
        return goal;
    }
}

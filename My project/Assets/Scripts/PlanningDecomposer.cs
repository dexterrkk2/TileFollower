using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanningDecomposer : Decomposer
{
    public Graph graph;

    public Goal decompose(Kinematic character, Goal goal)
    {
        //float graphNodeStart = graph.getNode(character.transform.position);
        //float graphNodeEnd = graph.getNode(goal.position);
        //if(graphNodeStart == graphNodeEnd)
        //{
            //return goal;
        //}
        goal.position = character.transform.position;
        goal.hasPosition = true;
        return goal;
    }
}

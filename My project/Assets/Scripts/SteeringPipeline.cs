using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringPipeline : SteeringBehavior
{
    List<Targeter> targeters;
    List<Decomposer> decomposers;
    List<Constraint> constraints;
    Actuator actuator;
    Kinematic character;
    int constraintSteps;
    SteeringBehavior deadlock;
    List<GameObject> path;
    public override SteeringOutput getSteering()
    {
        Goal goal = new Goal();
        foreach (Targeter targeter in targeters)
        {
            Goal targeterGoal = targeter.getGoal(character);
            goal.updateChannels(targeterGoal);
        }
        foreach(Decomposer decomposer in decomposers)
        {
            goal = decomposer.decompose(character, goal);
        }
        for(int i=0; i<constraintSteps; i++)
        {
            path = actuator.getPath(character, goal);
            foreach(Constraint constraint in constraints)
            {
                if (constraint.willViolate(path, goal))
                {
                    goal = constraint.suggest(character, path, goal);
                    break;
                }
            }
            return actuator.output(character, path, goal);
        }
        return deadlock.getSteering();
    }
}

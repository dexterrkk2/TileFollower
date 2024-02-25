using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingAvoidance : Kinematic
{
    PrioritySteering myMoveType;
    public List<Kinematic> targets;
    public float weight1;
    public float weight2;
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new PrioritySteering();
        myMoveType.groups = new List<BlendedSteering>();
        blendingSetup();
        myMoveType.character = this;
        myMoveType.target = myTarget;
    }

    // Update is called once per frame
    void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear *maxSpeed;
        steeringUpdate.angular = myMoveType.getSteering().angular * maxSpeed;
        base.Update();
    }
    public void blendingSetup()
    {
        BlendedSteering obstacleBlended = new BlendedSteering();
        ObstacleAvoidance obstacleAvoidance = new ObstacleAvoidance();
        BehaviourandWeight obstacleWeight = new BehaviourandWeight();
        Flocking flocking = new Flocking();
        flocking.myTarget = myTarget;
        flocking.targets = targets;
        flocking.weight1 = weight1;
        flocking.weight2 = weight2;
        obstacleAvoidance.target = myTarget;
        obstacleAvoidance.character = this;
        obstacleWeight.Behavior = obstacleAvoidance;
        obstacleWeight.weight = weight1;
        obstacleBlended.behaviours = new List<BehaviourandWeight>();
        obstacleBlended.behaviours.Add(obstacleWeight);
        myMoveType.groups.Add(obstacleBlended);
        myMoveType.groups.Add(flocking);
    }
}

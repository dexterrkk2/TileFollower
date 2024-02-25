using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : PrioritySteering
{
    
    public List<BlendedSteering> blendedSteerings = new List<BlendedSteering>();
    public float seperateThreshold;
    public List<Kinematic> targets;
    public void Setup()
    {
        //Declare Behaviours
        BlendedSteering obstacleBlend = new BlendedSteering();
        BehaviourandWeight obstacleWeight = new BehaviourandWeight(); 
        BlendedSteering seperateBlend = new BlendedSteering();
        BehaviourandWeight seperateWeight = new BehaviourandWeight();
        Separation seperate = new Separation(); 
        ObstacleAvoidance obstacleAvoidance = new ObstacleAvoidance();
        BlendedSteering seekBlend = new BlendedSteering();
        BehaviourandWeight seekWeight = new BehaviourandWeight();
        Pursue seek = new Pursue();
        seekBlend.behaviours = new List<BehaviourandWeight>();
        obstacleBlend.behaviours = new List<BehaviourandWeight>();
        seperateBlend.behaviours = new List<BehaviourandWeight>();    
        //Behaviour Setup
        seperate.threshold = seperateThreshold;
        seperate.targets = targets;
        seek.target = targets[0].gameObject;
        obstacleAvoidance.character = character;
        obstacleAvoidance.target = target;
        seek.character = character;
        seperate.character = character;
        //Behavior Weight setup
        obstacleWeight.Behavior = obstacleAvoidance;
        obstacleWeight.weight = 10;
        seperateWeight.Behavior = seperate;
        seperateWeight.weight = 5;
        seekWeight.Behavior = seek;
        seekWeight.weight = 5;
        seekBlend.behaviours.Add(seekWeight);
        //bblend Setup
        obstacleBlend.behaviours.Add(obstacleWeight);
        seperateBlend.behaviours.Add(seperateWeight);
        blendedSteerings.Add(obstacleBlend);
        blendedSteerings.Add(seperateBlend);
        blendedSteerings.Add(seekBlend);
    }
    public override SteeringOutput getSteering()
    {
        base.groups = blendedSteerings;
        return base.getSteering();
    }
}
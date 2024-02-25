using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : BlendedSteering
{
    public List<Kinematic> targets;
    public float weight1;
    public float weight2;
    public GameObject myTarget;
    public void RunFlocking()
    {
        BehaviourandWeight SeperationWeight = new BehaviourandWeight();
        behaviours = new List<BehaviourandWeight>();
        Separation seperation = new Separation();
        seperation.targets = targets;
        seperation.character = character;
        SeperationWeight.Behavior = seperation;
        SeperationWeight.weight = weight1;
        behaviours.Add(SeperationWeight);
        /*Cohesion cohesion = new Cohesion();
        cohesion.targets = targets;
        cohesion.character = this;
        BehaviourandWeight cohesioWeighted = new BehaviourandWeight();
        cohesioWeighted.Behavior = cohesion;
        cohesioWeighted.weight = weight2;
        myMoveType.behaviours.Add(cohesioWeighted);*/
        /*Debug.Log("Weights Setup");
        Arrive align = new Arrive();
        align.target = myTarget;
        align.character = this;
        BehaviourandWeight AlighnWeight = new BehaviourandWeight();
        AlighnWeight.Behavior = align;
        AlighnWeight.weight = weight3;
        myMoveType.behaviours.Add(AlighnWeight);
       */
        Seek seek = new Seek();
        seek.target = myTarget;
        seek.character = character;
        BehaviourandWeight SeekWeight = new BehaviourandWeight();
        SeekWeight.Behavior = seek;
        SeekWeight.weight = weight2;
        behaviours.Add(SeekWeight);
        base.getSteering();
    }
}

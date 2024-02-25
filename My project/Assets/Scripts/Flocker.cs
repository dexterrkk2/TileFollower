using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : Kinematic
{
    Flocking myMoveType;
    public float weight1;
    public float weight2;
    public float weight3;
    public float weight4;
    public bool flee = false;
    public List<Kinematic> targets;
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Flocking();
        myMoveType.weight1 = weight1;
        myMoveType.weight2 = weight2;
        myMoveType.targets = targets;
        myMoveType.character = this;
        myMoveType.myTarget = myTarget;
        myMoveType.flee = flee;
        myMoveType.RunFlocking();
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
   

}

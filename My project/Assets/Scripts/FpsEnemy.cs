using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class FpsEnemy : Kinematic, INPC
{
    public int hp;
    RangedEnemy myMoveType;
    public List<Kinematic> targets;
    public bool flee = false;
    public float shootDistance;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;
    // Start is called before the first frame update
    void Start()
    {
        //targets = FindObjectsOfType<Kinematic>().ToList<Kinematic>();
        myMoveType = new RangedEnemy();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.targets = targets;
        myMoveType.flee = flee;
        myMoveType.seperateThreshold = shootDistance;
        myMoveType.Setup();
        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
        base.Update();
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}


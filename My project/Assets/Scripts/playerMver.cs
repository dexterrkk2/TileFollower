using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerMver : Kinematic, INPC
{
    public int hp;
    playerMvmnt myMoveType;
    LookWhereGoing mySeekRotateType;
    LookWhereGoing myFleeRotateType;
    public float speed;
    public bool flee = false;
    public float RotateAmount;
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new playerMvmnt();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = flee;
        myMoveType.speed = speed;
        myMoveType.RotateAmount = RotateAmount;
        mySeekRotateType = new LookWhereGoing();
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
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}

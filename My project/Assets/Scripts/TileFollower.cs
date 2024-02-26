using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFollower : Kinematic
{
    public Node start;
    public Node goal;
    Graph myGraph;

    FollowPath myMoveType;
    LookWhereGoing myRotateType;

    //public GameObject[] myPath = new GameObject[4];
    GameObject[] myPath;
    public TileMaker map;
    // Start is called before the first frame update
    void Start()
    {
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        Graph myGraph = new Graph();
        map.MakeMap();
        myGraph.Build();
        start = map.tiles[0,0];
        transform.position = start.transform.position;
        goal = map.tiles[map.mapSizeX-1,map.mapSizeY-1];
        List<Connection> path = Dijstra.pathfind(myGraph, start, goal);
        // path is a list of connections - convert this to gameobjects for the FollowPath steering behavior
        myPath = new GameObject[path.Count + 1];
        int i = 0;
        foreach (Connection c in path)
        {
            Debug.Log("from " + c.getFromNode() + " to " + c.getToNode() + " @" + c.getCost());
            myPath[i] = c.getFromNode().gameObject;
            i++;
        }
        myPath[i] = goal.gameObject;

        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.path = myPath;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}

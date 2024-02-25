using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool hasPosition = false;
    public bool hasOrientation = false;
    public bool hasVelocity = false;
    public bool hasRotation = false;
    public Vector3 position;
    public float orientation;
    public Vector3 velocity;
    public float rotation;
    public void updateChannels(Goal other)
    {
        if (other.hasPosition)
        {
            position = other.position;
            hasPosition = true;
        }
        if (other.hasOrientation)
        {
            orientation = other.orientation;
            hasOrientation = true;
        }
        if (other.hasVelocity)
        {
            velocity = other.velocity;
            hasVelocity = true;
        }
        if (other.hasRotation)
        {
            rotation = other.rotation;
            hasRotation = true;
        }
    }
}

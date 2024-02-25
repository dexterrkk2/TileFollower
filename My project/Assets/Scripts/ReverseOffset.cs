using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseOffset
{
    public Vector3 Reverse(GameObject thingToOffset)
    {
        Vector3 rotation = thingToOffset.transform.rotation.eulerAngles;
        return -rotation;
    }
}

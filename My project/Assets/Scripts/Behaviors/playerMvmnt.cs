using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMvmnt : Seek
{
    public float speed;
    public float RotateAmount;
    public override SteeringOutput getSteering()
    {
        SteeringOutput output = new SteeringOutput();
        Vector3 direction = character.transform.forward * speed;
        if (Input.GetKey(KeyCode.W))
        {
            output.linear = direction;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            output.linear = -direction;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Quaternion rotation = new Quaternion();
            rotation = Quaternion.Euler(0, RotateAmount, 0);
            character.transform.Rotate(rotation.eulerAngles);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Quaternion rotation = new Quaternion();
            rotation = Quaternion.Euler(0, -RotateAmount, 0);
            character.transform.Rotate(rotation.eulerAngles);
        }
        return output;
    }
}

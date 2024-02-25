using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FireGun : MonoBehaviour
{
    public GameObject firepoint;
    public GameObject bulletPrefab;
    public GameObject gun;
    public GameObject Enemy;
    public float shootDistance;
    public GameObject target;
    public bool isPlayer;
    public float startDelay;
    float delay;
    public void Start()
    {
        delay = startDelay;
    }
    public void FixedUpdate()
    {
        if (isPlayer)
        {
            if (Input.GetButton("Fire1"))
            {
                if (delay <= 0)
                {
                    FireBullet();
                    delay = startDelay;
                }
            }
        }
        else
        {
            getPosition();
        }
        delay -= Time.deltaTime;
    }
    public void getPosition()
    {
        FiringSolution fire = new FiringSolution();
        Nullable<Vector3> aimVector = fire.CalculateFiringSolution(firepoint.transform.forward, target.transform.position, shootDistance, Physics.gravity);
        ReverseOffset reverse = new ReverseOffset();
        Vector3 offsetRotation = reverse.Reverse(Enemy);
        if(aimVector.HasValue)
        {
            gun.transform.LookAt(aimVector.Value, Vector3.up);
            gun.transform.Rotate(offsetRotation);
            if (delay <= 0)
            {
                delay = startDelay;
                FireBullet();
            }
        }
    }
    public void FireBullet()
    {
        GameObject bullet =Instantiate(bulletPrefab, firepoint.transform.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Vector3 direction = firepoint.transform.forward * shootDistance;
        bulletRb.AddForce(direction, ForceMode.VelocityChange);
    }
}

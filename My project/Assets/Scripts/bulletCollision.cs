using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    public int damage;
    public bool enenyBullet;
    private void OnCollisionEnter(Collision collision)
    {
        INPC npc = collision.gameObject.GetComponent<INPC>();
        if (npc != null)
        {
            if(enenyBullet && collision.gameObject.tag == "Player")
            {
                npc.TakeDamage(damage);
            }
            else if(!enenyBullet && collision.gameObject.tag == "Enemy")
            {
                npc.TakeDamage(damage);
            }
        }
        else
        {
            if(collision.gameObject.tag == "Ground")
            {
                Destroy(this.gameObject);
            }
        }
    }
}

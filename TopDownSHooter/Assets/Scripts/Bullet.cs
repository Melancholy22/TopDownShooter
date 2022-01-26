using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable
{
    [SerializeField]
    private GameObject hitEffect;

    public int damagePoint = 1;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }*/

    protected override void OnCollide(Collider2D coll)
    {
            if (coll.name != "player" && coll.tag != "Weapon")
            {
                //Debug.Log(coll.name);
                Damage dmg = new Damage //Sends the data the the damage structure
                {
                    damageAmount = damagePoint,
                };
                coll.SendMessage("ReceiveDamage", dmg);
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(effect, 1f);
        }
    }
}

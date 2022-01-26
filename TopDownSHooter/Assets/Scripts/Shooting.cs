using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Collidable
{
    [SerializeField]
    private GameObject bulletPre;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float bulletVel;

    private Animator anim;
    public int damagePoint = 1;

    //Swing stats
    private float cooldown = 0.5f;
    private float lastSwing;
    private float pushForce = 1;

    private new void Start()
    {
        base.Start(); // Needed for OnCollide function
        anim = GetComponent<Animator>(); 
    }
    // Update is called once per frame
    new void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            if (Time.time - lastSwing > cooldown) //Cooldown for swinging
            {
                lastSwing = Time.time;
                Swing();
            }
        }
        base.Update(); //Needed for the OnCollide method to work
    }
    
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletVel, ForceMode2D.Impulse); //Makes bullet fly at that velocity
    }
    
    void Swing()
    {
        anim.SetTrigger("Swing");
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name != "player")
            {
                //Debug.Log(coll.name);
                Damage dmg = new Damage //Sends the data the the damage structure
                {
                    damageAmount = damagePoint,
                    origin = transform.position,
                    pushForce = pushForce
                };
                coll.SendMessage("ReceiveDamage", dmg);
            }
        }
    }
}

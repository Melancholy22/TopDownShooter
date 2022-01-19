using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPre;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float bulletVel = 20f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            Swing();
        }
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
}

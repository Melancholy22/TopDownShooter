using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMechanic : MonoBehaviour
{
    [SerializeField]
    private GameObject shield;

    [SerializeField]
    private Transform shieldStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shield();
        }
    }

    void Shield()
    {
        GameObject bullet = Instantiate(shield, shieldStart.position, shieldStart.rotation);
        
    }
}

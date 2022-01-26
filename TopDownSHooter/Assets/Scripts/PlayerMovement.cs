using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Mover
{
    private void FixedUpdate()
    {
        //Where the player wants to be
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }
}

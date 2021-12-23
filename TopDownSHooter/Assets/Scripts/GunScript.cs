using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Rigidbody2D rb;

    Vector2 mousePos;

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position);
        Vector2 lookDir = mousePos - rb.position; //Subtracting two vectors together gets a vector that points from one to the other
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //Atan2 is a function that returns the angle from x-axis to the direction axis. Since it returns radians we want to convert it to degrees and offset it by 90 degrees
        rb.rotation = angle;
    }
}

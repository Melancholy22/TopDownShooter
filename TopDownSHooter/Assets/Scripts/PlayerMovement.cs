using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Field Variables
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; //Difference between current position and where you want to be.
    private RaycastHit2D hit; //Checks if we are allowed to go there or not

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Where the player wants to be
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset MoveDelta - So it doesn't just queue up the same move
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction - Whether face right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 0);

        //Make sure we can move in the direction, by casting a box there first. If box returns null, we can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make the sprite actually move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make the sprite actually move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}

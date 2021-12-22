using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; //Difference between current position and where you want to be.

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
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

        // Make the sprite actually move
        transform.Translate(moveDelta * Time.deltaTime);
    }
}

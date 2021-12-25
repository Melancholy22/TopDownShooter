using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairLocation : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    void Update()     //In each frame...
    {
        transform.position = Input.mousePosition;
    }
}

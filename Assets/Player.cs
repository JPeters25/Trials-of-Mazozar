using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // Reset moveDelta
        moveDelta = Vector3.zero;

        // Movement input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Debug.Log(x);
        Debug.Log(y);
    }
}

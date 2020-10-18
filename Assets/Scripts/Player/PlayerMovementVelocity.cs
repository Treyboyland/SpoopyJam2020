using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVelocity : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    [SerializeField]
    bool move = true;

    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        Vector2 movement = new Vector2();
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");
        if (horizontalAxis != 0)
        {
            movement.x = horizontalAxis * speed;
        }
        if (verticalAxis != 0)
        {
            movement.y = verticalAxis * speed;
        }

        if (move && movement != new Vector2())
        {
            body.velocity = movement;
        }
    }
}

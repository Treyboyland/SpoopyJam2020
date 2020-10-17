using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        Vector3 movement = new Vector3();
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");
        movement.x = horizontalAxis * Time.deltaTime * speed;
        movement.y = verticalAxis * Time.deltaTime * speed;

        if (move)
        {
            body.MovePosition(transform.position + movement);
        }
    }
}

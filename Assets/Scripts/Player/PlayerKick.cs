using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenKicks = 0;

    [SerializeField]
    float raycastDistance = 0;

    [SerializeField]
    float kickPower = 0;

    [SerializeField]
    PlayerLookTowardsMouse playerMouse = null;

    public const string KICK_COMMAND = "Kick";

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    // private void FixedUpdate()
    // {
    //     if (Input.GetButton(KICK_COMMAND) && elapsed >= secondsBetweenKicks)
    //     {
    //         elapsed = 0;
    //         var mousePos = playerMouse.MouseToWorldPoint();
    //         var raycast = Physics2D.Raycast(transform.position, mousePos,
    //             raycastDistance, LayerMask.GetMask("Enemy"));

    //         if (raycast.collider != null)
    //         {
    //             Debug.LogWarning("Collision Found");
    //             var enemyBody = raycast.collider.GetComponent<Rigidbody2D>();
    //             if (enemyBody != null)
    //             {
    //                 enemyBody.AddForce(mousePos.normalized * kickPower, ForceMode2D.Impulse);
    //             }
    //         }
    //         else
    //         {
    //             Debug.LogWarning("No hit");
    //         }
    //     }
    // }

    public void KickTest()
    {
        var mousePos = playerMouse.MouseToWorldPoint();
        var raycast = Physics2D.Raycast(transform.position, mousePos,
            raycastDistance, LayerMask.GetMask("Enemy"));

        if (raycast.collider != null)
        {
            Debug.LogWarning("Collision Found");
            var enemyBody = raycast.collider.GetComponent<Rigidbody2D>();
            if (enemyBody != null)
            {
                enemyBody.AddForce(mousePos.normalized * kickPower, ForceMode2D.Impulse);
            }
        }
        else
        {
            Debug.LogWarning("No hit");
        }
    }
}

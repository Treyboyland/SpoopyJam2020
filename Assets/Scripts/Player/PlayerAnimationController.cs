using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator = null;

    [SerializeField]
    SpriteRenderer playerSprite = null;

    [SerializeField]
    Player playerScript = null;

    [SerializeField]
    Rigidbody2D playerBody = null;

    [SerializeField]
    PlayerLookTowardsMouse playerMouse = null;

    [SerializeField]
    float velocityThreshold = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerScript.OnDamageTaken.AddListener(() => animator.SetTrigger("Damaged"));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(playerBody.velocity);
        //Disgusting line
        animator.SetBool("Moving", !(Mathf.Abs(playerBody.velocity.x) < velocityThreshold && Mathf.Abs(playerBody.velocity.y) < velocityThreshold));
        playerSprite.flipX = transform.position.x > playerMouse.MouseToWorldPoint().x;
        animator.SetBool("Attacking", Input.GetButton(PlayerShoot.FIRE_COMMAND));
        animator.SetBool("Kicking", Input.GetButton(PlayerKick.KICK_COMMAND));
    }
}

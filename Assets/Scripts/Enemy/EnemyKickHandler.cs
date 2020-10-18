using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKickHandler : MonoBehaviour, IKickHandler
{
    [SerializeField]
    EnemyAI enemyAI = null;

    [SerializeField]
    Rigidbody2D body = null;

    [SerializeField]
    float velocityThreshold = 0;

    public void Kick(Vector2 force, ForceMode2D mode)
    {
        //TODO: This is incredibly disgusting...
        StartCoroutine(WaitUntilStillThenContinue(force, mode));
    }

    IEnumerator WaitUntilStillThenContinue(Vector2 force, ForceMode2D mode)
    {
        enemyAI.isKicked = true;
        body.AddForce(force, mode);

        while (Mathf.Abs(body.velocity.x) > velocityThreshold || Mathf.Abs(body.velocity.y) > velocityThreshold)
        {
            yield return null;
        }

        enemyAI.isKicked = false;
    }
}

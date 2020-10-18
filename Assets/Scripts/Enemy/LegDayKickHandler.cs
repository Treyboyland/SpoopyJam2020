using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDayKickHandler : MonoBehaviour, IKickHandler
{
    [SerializeField]
    LegdayAI legDayAI = null;

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
        legDayAI.isKicked = true;
        body.AddForce(force, mode);

        while (Mathf.Abs(body.velocity.x) > velocityThreshold || Mathf.Abs(body.velocity.y) > velocityThreshold)
        {
            yield return null;
        }

        legDayAI.isKicked = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKickHandler
{
    void Kick(Vector2 force, ForceMode2D forceMode);
}

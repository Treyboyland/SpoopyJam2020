using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSprite : MonoBehaviour
{
    private void OnMouseDown()
    {
        Application.Quit();
    }
}

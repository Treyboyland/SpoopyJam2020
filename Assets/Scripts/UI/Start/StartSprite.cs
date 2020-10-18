using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSprite : MonoBehaviour
{
    [SerializeField]
    string sceneName = null;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

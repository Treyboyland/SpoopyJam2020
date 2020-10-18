using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuKey : MonoBehaviour
{
    [SerializeField]
    string sceneName = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}

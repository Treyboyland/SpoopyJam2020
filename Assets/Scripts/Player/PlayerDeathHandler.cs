using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    Player player;

    [SerializeField]
    PlayerDeathParticlePool pool;

    // Start is called before the first frame update
    void Start()
    {
        player.OnLivesChanged.AddListener(KillIfDead);
    }

    void KillIfDead(int lives)
    {
        if (lives == 0)
        {
            var particle = pool.GetObject();
            particle.transform.position = player.transform.position;
            particle.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            source.Play();
            StartCoroutine(SendBack());
        }
    }

    IEnumerator SendBack()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
}

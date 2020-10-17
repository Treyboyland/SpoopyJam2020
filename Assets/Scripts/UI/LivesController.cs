using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    [SerializeField]
    LivesSprite lifeSpritePrefab = null;

    [SerializeField]
    Player player = null;

    List<LivesSprite> allLives = new List<LivesSprite>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeCounter();
        player.OnLivesChanged.AddListener(ChangeLives);
    }

    void InitializeCounter()
    {
        for (int i = 0; i < player.Lives; i++)
        {
            var lifeCounter = Instantiate(lifeSpritePrefab, transform) as LivesSprite;
            lifeCounter.HasLife = true;
            lifeCounter.gameObject.SetActive(true);
            allLives.Add(lifeCounter);
        }
    }

    void ChangeLives(int lives)
    {
        if (lives > allLives.Count)
        {
            //TODO: Not sure what to do in this situation...
            return;
        }

        for (int i = 0; i < allLives.Count; i++)
        {
            allLives[i].HasLife = i < lives;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    SpawnObject smallEnemyPrefab = null;


    [SerializeField]
    SpawnObject legDayPrefab = null;

    [SerializeField]
    MonoBehaviour enemyPrefabSpawn;

    [SerializeField]
    Vector3 minSpawn = new Vector3();

    [SerializeField]
    float smallGuySpawnProbability = 0.9f;

    [SerializeField]
    Vector3 maxSpawn = new Vector3();

    /// <summary>
    /// Total time before which this activates, seconds between spawns, number of spawns
    /// </summary>
    [SerializeField]
    List<Vector3> listOfElapsedAndInterimsAndSpawns = null;

    [SerializeField]
    PlaySpace space;

    float totalTime = 0;

    float elapsed = 0;

    const int LITTLE_DUDES_PER_BIG_DUDE = 3;


    int spawnCount = 0;
    const int MAX_SPAWNS_WO_BIG_DUDE = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        elapsed += Time.deltaTime;
        var parameters = GetParamsForSpawn();
        if (elapsed >= parameters.y || (!MasterPool.Pool.AreAnyActive(enemyPrefabSpawn) &&
            !MasterPool.Pool.AreAnyActive(legDayPrefab) && !MasterPool.Pool.AreAnyActive(smallEnemyPrefab)))
        {
            elapsed = 0;
            Spawn(parameters.z);
        }
    }

    Vector3 GetParamsForSpawn()
    {
        if (listOfElapsedAndInterimsAndSpawns.Count == 0)
        {
            return new Vector3(0, 10, 2);
        }
        foreach (var parameter in listOfElapsedAndInterimsAndSpawns)
        {
            if (totalTime > parameter.x)
            {
                continue;
            }
            return parameter;
        }

        return listOfElapsedAndInterimsAndSpawns[listOfElapsedAndInterimsAndSpawns.Count - 1];
    }

    Vector2 GetRandomWorldPosition()
    {
        var x = UnityEngine.Random.Range(minSpawn.x, maxSpawn.x);
        var y = UnityEngine.Random.Range(minSpawn.y, maxSpawn.y);
        return new Vector2(x, y);
    }

    bool SpawnSmall()
    {
        return Random.Range(0.0f, 1.0f) < smallGuySpawnProbability;
    }

    void Spawn(float numSpawns)
    {
        numSpawns = (int)numSpawns;
        var spawnObject = SpawnSmall() ? smallEnemyPrefab : legDayPrefab;

        if (spawnObject == legDayPrefab)
        {
            spawnCount = 0;
        }
        else
        {
            spawnCount++;
            if (spawnCount > MAX_SPAWNS_WO_BIG_DUDE)
            {
                spawnCount = 0;
                spawnObject = legDayPrefab;
            }
        }


        for (int i = 0; i < numSpawns; i++)
        {
            //Spawn only one big dude per spawn count
            var prefabToSpawn = spawnObject;
            if (prefabToSpawn == legDayPrefab && i % LITTLE_DUDES_PER_BIG_DUDE != 0)
            {
                prefabToSpawn = smallEnemyPrefab;
            }
            var spawnedEnemy = MasterPool.Pool.GetObject(prefabToSpawn);
            var spawnLocation = GetRandomWorldPosition();

            spawnedEnemy.transform.position = spawnLocation;
            spawnedEnemy.gameObject.SetActive(true);
        }
    }
}

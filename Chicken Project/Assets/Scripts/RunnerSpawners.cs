using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawners : MonoBehaviour
{
    private bool canSpawnEnemies = true;
    public Transform[] spawners;
    public List<int> randomTransforms;
    public GameObject enemyPrefab;
    public float time;
    public int currentRoundSpawns = 1;
    public int currentRoundSpawnsDone = 0;
    public int rounds;

    protected void GetRandomSpawnPoints()
    {
        randomTransforms.Clear();

        for(int i = 0; i<spawners.Length-2; i++)
        {
            GetRandomInt();
        }
    }

    protected void GetRandomInt()
    {
        bool existsInList = false;
        int rand = Random.Range(0, spawners.Length);
        foreach(int i in randomTransforms)
        {
            if(i == rand)
            {
                existsInList = true;
            }
        }

        if(existsInList == true)
        {
            GetRandomInt();
        }
        else
        {
            randomTransforms.Add(rand);
        }
    }

    protected void SpawnEnemies()
    {
        if(canSpawnEnemies == true)
        {
            StartCoroutine(SpawnWithCooldown());
        }
    }

    protected IEnumerator SpawnWithCooldown()
    {
        canSpawnEnemies = false;
        GetRandomSpawnPoints();

        for (int i = 0; i < randomTransforms.Count; i++)
        {
            Transform targetTransform = spawners[randomTransforms[i]];
            GameObject enemyInstance = Instantiate(enemyPrefab);
            enemyInstance.transform.parent = targetTransform;
            enemyInstance.transform.position = targetTransform.position;
            enemyInstance.transform.rotation = targetTransform.rotation;
        }
        yield return new WaitForSeconds(1);
        canSpawnEnemies = true;
    }

    protected void Update()
    {
        SpawnEnemies();
    }
}

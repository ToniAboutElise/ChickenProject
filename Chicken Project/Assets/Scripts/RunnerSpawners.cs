using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawners : MonoBehaviour
{
    private bool canSpawnEnemies = true;
    public Transform[] spawners;
    public List<int> randomTransforms;
    public List<int> bonusTransforms;
    public GameObject enemyPrefab;
    public GameObject bonusPrefab;
    protected float enemiesVelocity;
    public float time;
    protected List<DifficultyLevel> levels;
    public int rounds;
    public RunnerController runnerController;
    public int freeSpaces;

    public Level level = Level.Easy;

    public enum Level
    {
        Easy,
        Normal,
        High
    }

    private void Start()
    {
        SetDifficultyLevel(level);
    }

    public void SetDifficultyLevel(Level level)
    {
            switch (level)
        {
            case Level.Easy:
                DifficultyLevel easy = new DifficultyLevel();
                easy.enemiesVelocity = 10;
                enemiesVelocity = easy.enemiesVelocity;
                easy.playerRotationVelocity = 2.5f;
                runnerController.playerRotationVelocity = easy.playerRotationVelocity;
                easy.freeSpaces = 4;
                freeSpaces = easy.freeSpaces;
                break;
        }
    }

    protected void GetRandomSpawnPoints()
    {
        randomTransforms.Clear();
        bonusTransforms.Clear();

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

    protected void GetBonusSpawns()
    {
        bool existsInList = false;
        int rand = Random.Range(0, spawners.Length);
        foreach (int i in randomTransforms)
        {
            if (i == rand)
            {
                existsInList = true;
            }
        }

        if (existsInList == true)
        {
            GetBonusSpawns();
        }
        else
        {
            bonusTransforms.Add(rand);
        }
    }

    protected void SpawnEnemiesAndBonus()
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
        GetBonusSpawns();

        for (int i = 0; i < randomTransforms.Count; i++)
        {
            Transform targetTransform = spawners[randomTransforms[i]];
            GameObject enemyInstance = Instantiate(enemyPrefab);
            enemyInstance.GetComponent<RunnerEntity>().enemiesVelocity = enemiesVelocity;
            enemyInstance.transform.parent = targetTransform;
            enemyInstance.transform.position = targetTransform.position;
            enemyInstance.transform.rotation = targetTransform.rotation;
        }

        for (int i = 0; i < bonusTransforms.Count; i++)
        {
            Transform targetTransform = spawners[bonusTransforms[i]];
            GameObject bonusInstance = Instantiate(bonusPrefab);
            bonusInstance.GetComponent<RunnerEntity>().enemiesVelocity = enemiesVelocity;
            bonusInstance.transform.parent = targetTransform;
            bonusInstance.transform.position = targetTransform.position;
            bonusInstance.transform.rotation = targetTransform.rotation;
        }

        yield return new WaitForSeconds(1);
        canSpawnEnemies = true;
    }

    protected void Update()
    {
        SpawnEnemiesAndBonus();
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;   

public class Spawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> EnemysPrefabs;

    public float timeBetweenSpawns;
    public float spawnDelay;

    public int currentWaves;
    private List<GameObject> aliveEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(Waves());
    }
    
    IEnumerator Waves()
    {
        while (true)
        { 
            yield return new WaitForSeconds(timeBetweenSpawns);

            currentWaves++;
            int enemiesToSpawn = 5+ currentWaves * 2;

            Debug.Log("Wave: " + currentWaves + " Enemies to spawn: " + enemiesToSpawn);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitUntil(() => aliveEnemies.Count == 0);

        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Count == 0 || EnemysPrefabs.Count == 0)
         return;

        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject randomEnemy = EnemysPrefabs[Random.Range(0, EnemysPrefabs.Count)];

        GameObject newEnemy = Instantiate(randomEnemy, randomPoint.position, randomPoint.rotation);
        aliveEnemies.Add(newEnemy);

        /*EnemyHealth health = newEnemy.GetComponent<EnemyHealth>();  
        if (health != null)
        {
            health.OnDeath += () => aliveEnemies.Remove(newEnemy);
        }*/
    }
}

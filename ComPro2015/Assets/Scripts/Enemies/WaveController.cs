using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {
    public int wave = 0;
    public int enemiesPerWave = 5;
    public float waveMultiplier = 1.5f;
    public float timeBetweenWaves = 25;
    public EnemySpawn[] enemySpawns;
    private GameObject enemyContainer;
    private float elapsedTime;
    private float spawnTimer = 1;
    private int enemiesSpawnedThisWave;

	// Use this for initialization
	void Start () {

	}   
	
	// Update is called once per frame
	void Update () {
        if (enemyContainer == null)
        {
            enemyContainer = GameObject.Find("Enemies");
            for(int i = 0; i < enemySpawns.Length;i++){
                enemySpawns[i].enemyContainer = enemyContainer;
            }
        }
        else
        {
            if (elapsedTime >= spawnTimer && enemiesSpawnedThisWave <= enemiesPerWave*(waveMultiplier*wave))
            {
                elapsedTime = 0;
                SpawnSubWave();
                enemiesSpawnedThisWave++;
            }
            else if (enemiesSpawnedThisWave > enemiesPerWave * (waveMultiplier * wave))
            {
                if (enemyContainer.transform.childCount == 0) { 
                    enemiesSpawnedThisWave = 0;
                    wave++;
                    elapsedTime = -timeBetweenWaves;
                }
            }
        }
        elapsedTime += Time.deltaTime; 
	}

    void SpawnSubWave()
    {
        foreach (EnemySpawn spawn in enemySpawns)
        {
            spawn.SpawnEnemies();
        }
    }


}

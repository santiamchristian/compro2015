using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public Transform[] targets;
    public GameObject enemyContainer;
    public GameObject enemyPrefab; 
    public int wave;
    public float spawnTimer;


    public void SpawnEnemies()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        newEnemy.GetComponent<Enemy>().targets = targets;
    }
}

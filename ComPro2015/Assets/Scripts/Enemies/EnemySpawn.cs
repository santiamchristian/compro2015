using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public Transform[] targets;
    public GameObject enemyContainer;
    public GameObject enemyPrefab; 
    public int wave;
    public float spawnTimer;
    private float elapsedTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyContainer == null)
        {
            enemyContainer = GameObject.Find("Enemies");
        }
        else {
            if (elapsedTime >= spawnTimer)
            {
                SpawnEnemies();
            }
        }
        elapsedTime += Time.deltaTime; 
	}

    void SpawnEnemies()
    {
        Transform newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as Transform;
        newEnemy.parent = enemyContainer.transform;
        newEnemy.GetComponent<Enemy>().targets = targets;
    }
}

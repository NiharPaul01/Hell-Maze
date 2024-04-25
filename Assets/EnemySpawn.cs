using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] private GameObject enemy;
    [SerializeField] private float xPos;
    [SerializeField] private float zPos;
    [SerializeField] private int maxEnemyCount; // Change to desired max enemies
    int enemyCount = 0;
    

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private float timer = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime; // Update timer every frame

        // Reset enemy count and clear spawned enemies after 50 seconds
        if (timer >= 90f)
        {
            enemyCount = 0;
            timer = 0f; 
        }
        while (enemyCount < maxEnemyCount)
        {
            xPos = Random.Range(-110, 110);
            zPos = Random.Range(-110, 110);
            GameObject spawnedEnemy = Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            enemyCount++;
            spawnedEnemies.Add(spawnedEnemy);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] private GameObject enemy;
    [SerializeField] private float xPos;
    [SerializeField] private float zPos;
    [SerializeField] private int maxEnemyCount; // Change to desired max enemies
    int enemyCount = 0;
    private float timer = 0f;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        


        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < maxEnemyCount)
        {
            xPos = Random.Range(-110, 110);
            zPos = Random.Range(-110, 110);
            GameObject spawnedEnemy = Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            enemyCount++;
            spawnedEnemies.Add(spawnedEnemy);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;

        // Reset spawned enemy count after 1 minute
        if (timer >= 60f)
        {
            enemyCount = 0;
            timer = 0f; // Reset timer
        }
    }
}

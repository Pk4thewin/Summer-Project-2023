using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Path[] paths;
    public float timeBetwweenWaves;
    private float countDown = 2f;
    private int waveCount = 1;

    void Update(){
        if(countDown <= 0f){
            StartCoroutine(SpawnWave());
            countDown = timeBetwweenWaves;
        }
        countDown -= Time.deltaTime;
    }
    
    IEnumerator SpawnWave(){
        for(int i = 0; i < waveCount; i++){
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveCount++;
    }
    
    void SpawnEnemy(){
        // select a random spawn point from the array
        Path spawnPath = paths[Random.Range(0, paths.Length)];
        Transform enemy = Instantiate(enemyPrefab, spawnPath.GetWaypoint(0).position, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.SetPath(spawnPath);
    }
}

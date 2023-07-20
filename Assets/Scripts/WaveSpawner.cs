using UnityEngine;
using System.Collections;
public class WaveSpawner : MonoBehaviour
{
    //allow for multiple spawners
    public Transform enemyPrefab;
    public Transform spawnPoint;
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
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

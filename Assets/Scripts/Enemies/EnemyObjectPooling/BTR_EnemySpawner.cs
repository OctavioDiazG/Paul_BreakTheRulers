using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BTR_EnemySpawner : MonoBehaviour
{
    public BTR_ObjectPooler objectPooler;
    public GameObject[] spawnPoints;
    public bool isPlaying = true;
    public float radiusFromSpawnpoint;
    public string[] enemies = new string[]{"Ruler","TRuler","Squad","Transporter"};

    private int _timing = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = BTR_ObjectPooler.Instance;
        StartCoroutine(SpawnFromPaul(1));
    }


    private IEnumerator SpawnFromPaul(float timer)
    {

        while (isPlaying)
        {
            Debug.Log(_timing);
            if (_timing <= 10)
            {
                yield return new WaitForSeconds(timer);
                _timing++;
            }
            else if (_timing <= 70)
            {
                int random = Random.Range(0, spawnPoints.Length);
                Vector3 radiusSpawn = new Vector3(Random.Range(-radiusFromSpawnpoint,radiusFromSpawnpoint),0,Random.Range(-radiusFromSpawnpoint,radiusFromSpawnpoint));
                yield return new WaitForSeconds(timer);
                _timing++;
                switch (random)
                {
                    case 0:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[0].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 1:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[1].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 2:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[2].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 3:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[3].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 4:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[4].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 5:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[5].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 6:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[6].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                    case 7:
                        objectPooler.SpawnFromPool(enemies[Random.Range(0,enemies.Length)], spawnPoints[7].transform.position + radiusSpawn, Quaternion.identity);
                        break;
                }
            
            
            }
            else
            {
                yield return new WaitForSeconds(timer);
                _timing = 0;
            }

        }
    }
}

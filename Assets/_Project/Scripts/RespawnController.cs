using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public List<SpawnPoint> spawnPoints;
    public GameObject player;
    public Health health;
    
    public void Respawn()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Count);

        player.transform.position = spawnPoints[randomSpawnIndex].transform.position;
        player.transform.rotation = spawnPoints[randomSpawnIndex].transform.rotation;
        health.RestoreToDefault();
    }
}
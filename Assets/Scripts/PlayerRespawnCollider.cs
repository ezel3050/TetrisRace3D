using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null) return;
        List<Transform> spawnPoints;

        //If just passed the last station 
        if (player.currentStage < GameManager.instnace.currentLevel.stages.Count)
        {
            spawnPoints = GameManager.instnace.currentLevel.stages[player.currentStage].characterSpawnPoints;
        }
        else
        {
            spawnPoints = GameManager.instnace.currentLevel.stages[GameManager.instnace.currentLevel.stages.Count - 1].characterSpawnPoints;
        }

        player.MovePlayerToPosition(spawnPoints[Random.Range(0, spawnPoints.Count)].position);
    }
}
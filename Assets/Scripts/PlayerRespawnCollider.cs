using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null) return;
        List<Transform> spawnPoints = GameManager.instnace.currentLevel.stages[player.currentStage].characterSpawnPoints;
        player.MovePlayerToPosition(spawnPoints[Random.Range(0, spawnPoints.Count)].position);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{

    public static void DeactivateAllEnemyAis()
    {
        foreach(EnemyAI enemyAI in GameManager.instnace.enemyAIs)
        {
            enemyAI.gameObject.SetActive(false);
        }
    }




}

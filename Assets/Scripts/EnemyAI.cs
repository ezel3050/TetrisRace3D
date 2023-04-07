using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Character
{
    NavMeshAgent agent;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }







}

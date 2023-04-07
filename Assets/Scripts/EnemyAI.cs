using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Character
{
    [HideInInspector] public PuzzleStation puzzleStation;
    NavMeshAgent agent;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    public void StartTheGame()
    {
        //CALL THIS ONLY WHEN PUZZLE STATION IS SET!
        //LOOP


    }


    //agents finding their station
    //finding their puzzle pieces
    //picking the piece
    //bringing it to station
    //finsihg up the station
    //moving the next stage
    //on the last stage, going to the finish line
    
    //Generate puzzle pieces
    //sort them properly so it;s easy to recreate and AIs access them
    



}

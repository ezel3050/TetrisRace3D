using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Character
{
    [HideInInspector] public PuzzleStation puzzleStation;
    PuzzleBlock targetPuzzleBlock;
    NavMeshAgent agent;
    int currentStageIndex;
    PuzzleStation myCurrentStation;
    Action onReachDestination;


    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
    }

    public void Initilize(int id)
    {
        characterId = id;
        GetComponentInChildren<SkinnedMeshRenderer>().material = Resources.instance.idMaterials[id];
        SetCurrentStation();

    }


    void SetCurrentStation()
    {
        myCurrentStation =  GameManager.instnace.currentLevel.stages[currentStageIndex].stations[characterId];
    }

    //A
    public void StartTheLoop() 
    {
        SetTargetPuzzleBlock();
        agent.SetDestination(targetPuzzleBlock.transform.position);
        this.CallWithDelay(() => onReachDestination = ReachedPuzzleBlock, 2);
        
        
    }

    //B
    void ReachedPuzzleBlock()
    {
        PickUpPuzzleBlock(targetPuzzleBlock);
        targetPuzzleBlock = null; // Use blockInHand from now on
        agent.SetDestination(myCurrentStation.boxColliderDummy.position);
        this.CallWithDelay(() => onReachDestination = ReachedStationCollider, 3);


    }

    //C
    void ReachedStationCollider()
    {
        myCurrentStation.AddPuzzleBlockToStation(this);
        this.CallWithDelay(() =>
        {
            if (myCurrentStation.isStationConnectedToTheEnd())
            {
                ThisStationIsFinished();
            }
            else
            {
                StartTheLoop();
            }

        }, 1);
    }

    public void ThisStationIsFinished()
    {
        if (currentStageIndex == GameManager.instnace.currentLevel.stages.Count - 1)
        {
            RunToFinishline();
        }
        else
        {
            currentStageIndex++;
            SetCurrentStation();
        }
    }


    void RunToFinishline()
    {
        agent.SetDestination(GameManager.instnace.currentLevel.finishLine.transform.position);
        this.CallWithDelay(() => onReachDestination = ReachedFinishline, 1);
    }

    void ReachedFinishline()
    {
        GameManager.instnace.AIWon(this);

    }

    public void StopAI()
    {
        agent.isStopped = true;
        agent.enabled = false;
    }

    public void PlaySadAnimation()
    {
        animator.SetTrigger("Sad");
    }

    

    void SetTargetPuzzleBlock()
    {
        List<PuzzleBlock> myPuzzleBlocks = GameManager.instnace.currentLevel.stages[currentStageIndex].listOfListSpawnedPuzzles[characterId].listOfSpawnedPuzzles;
        targetPuzzleBlock = myPuzzleBlocks[UnityEngine.Random.Range(0, myPuzzleBlocks.Count)];
    }


    private void Update()
    {
        Animation();
        CheckOnReachedDestination();

    }

    void CheckOnReachedDestination()
    {
        if (!agent.enabled) return;
        if (agent.isStopped) return;
        if (onReachDestination == null) return;
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Action copyOfOnReachedAction = onReachDestination;

            onReachDestination = null;

            copyOfOnReachedAction?.Invoke();
        }
    }

    void Animation()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }


}

//stage, level design
//move tutorial
//main menu
//make a little shop using snow race 3d
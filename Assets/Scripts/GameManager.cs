using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instnace;
    public List<Level> levels;
    public List<EnemyAI> enemyAIs;
    [HideInInspector] public bool isGameStarted;
    public int currentLevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt(Globals.currentLevelIndexKey);
        }

        set
        {
            if (value >= levels.Count) value = 0;
            PlayerPrefs.SetInt(Globals.currentLevelIndexKey, value);
        }
    }

    public Level currentLevel
    {
        get
        {
            return levels[currentLevelIndex];
        }
    }


    private void Awake()
    {
        instnace = this;
    }

    private void Start()
    {
      //  InputManager.movementInputActive = false;
        ActivateCurrentLevel();
        InitilizeLevel();
    }



    void ActivateCurrentLevel()
    {
        DeactiveAllLevels();
        levels[currentLevelIndex].gameObject.SetActive(true);
    }

    void InitilizeLevel()
    {
        //REMEMBER THE LAST SPAWN POINT IS ALWAYS THE PLAYER 

        //PlayerInit

        //Player positioning
        Player.instance.Initilize(0);
        Player.instance.transform.position = currentLevel.spawnPoints[0].position;
        Player.instance.transform.rotation = currentLevel.spawnPoints[0].rotation;

        //AI
        Utilities.DeactivateAllEnemyAis();


        foreach(Stage stage in currentLevel.stages)
        {
            stage.InitilizeStations();
        }


        for (int i = 0; i < enemyAIs.Count; i++)
        {
            enemyAIs[i].gameObject.SetActive(true);

            //i + 1 cause Player is 0

            enemyAIs[i].Initilize(i + 1);
            enemyAIs[i].transform.position = currentLevel.spawnPoints[i + 1].position;
            enemyAIs[i].transform.rotation = currentLevel.spawnPoints[i + 1].rotation;

            // this.CallWithDelay(() => enemyAIs[index].StartTheLoop(), 3);
        }

        //LevelDesign
        int randomLevelDesignIndex = 0;
        randomLevelDesignIndex = Random.Range(0, currentLevel.stages[0].levelDesigns.Count);
        foreach (Stage stage in currentLevel.stages)
        {
            stage.SetLevelDesign(randomLevelDesignIndex);
        }
    }

    public void StartTheGame()
    {
        isGameStarted = true;
        InputManager.movementInputActive = true;
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            enemyAI.StartTheLoop();
        }
    }

    public void PlayerWon()
    {
        currentLevelIndex++;
        StopAllAIs();
        PlaySadAnimationOnAllAIs();
    }

    public void AIWon(EnemyAI victoriusAI)
    {
        MainMenu.instance.lostPanel.OpenPanel();
        StopAllAIs();

        //Stop AIs
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            if (enemyAI == victoriusAI)
            {
                enemyAI.Dance();
                enemyAI.transform.position = FinishLine.instance.firstPoint.position;
                enemyAI.transform.rotation = FinishLine.instance.firstPoint.rotation;
            }

            else
            {
                enemyAI.PlaySadAnimation();
            }
        }

    }

    public void StopAllAIs()
    {
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            enemyAI.StopAI();
        }
    }

    public void PlaySadAnimationOnAllAIs()
    {
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            enemyAI.PlaySadAnimation();
        }
    }

    void DeactiveAllLevels()
    {
        foreach (Level level in levels)
        {
            level.gameObject.SetActive(false);
        }
    }
}

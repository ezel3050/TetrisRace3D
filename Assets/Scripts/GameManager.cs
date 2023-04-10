using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instnace;
    public List<Level> levels;
    public List<EnemyAI> enemyAIs;

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
        InputManager.movementInputActive = false;
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

        //Player positioning
        Player.instance.transform.position = currentLevel.spawnPoints[0].position;
        Player.instance.transform.rotation = currentLevel.spawnPoints[0].rotation;
        //AI
        Utilities.DeactivateAllEnemyAis();

        for (int i = 0; i < enemyAIs.Count; i++)
        {
            enemyAIs[i].gameObject.SetActive(true);

            //i + 1 cause Player is 0

            enemyAIs[i].Initilize(i + 1);
            enemyAIs[i].transform.position = currentLevel.spawnPoints[i +1].position;
            enemyAIs[i].transform.rotation = currentLevel.spawnPoints[i +1].rotation;

            // this.CallWithDelay(() => enemyAIs[index].StartTheLoop(), 3);
        }
        
    }

    public void StartTheGame()
    {
        InputManager.movementInputActive = true;
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            enemyAI.StartTheLoop();
        }
    }

    public void AIWon(EnemyAI victoriusAI)
    {
        MainMenu.instance.lostPanel.OpenPanel();

        //Stop AIs
        foreach(EnemyAI enemyAI in enemyAIs)
        {
            if(enemyAI == victoriusAI)
            {
                enemyAI.Dance();
            }

            else
            {
                enemyAI.StopAI();
                enemyAI.PlaySadAnimation();
            }
        }

    }


    void DeactiveAllLevels()
    {
        foreach(Level level in levels)
        {
            level.gameObject.SetActive(false);
        }
    }



}

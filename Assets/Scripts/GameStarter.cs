using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
   

    void Update()
    {
        if (!InputManager.movementInputActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < Screen.height / 4)
            {
                GameManager.instnace.StartTheGame();
                MainMenu.instance.mainMenu.SetActive(false);
                MainMenu.instance.handTutorial.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}

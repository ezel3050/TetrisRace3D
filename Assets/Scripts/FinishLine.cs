using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Transform finishPoint;

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character == null) return;

        //isPlayer
        if(character.characterId == 0)
        {
            FinalPanel.instance.OpenPanel();

        }


    }



}

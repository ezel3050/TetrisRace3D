using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Transform finishPoint;
    public ParticleSystem finishLineParticle;

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

    public void PlayFinalParticle()
    {
        if (finishLineParticle == null) return;
        finishLineParticle.Play();
    }


}

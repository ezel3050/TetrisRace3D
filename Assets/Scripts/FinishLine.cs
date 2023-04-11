using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FinishLine : MonoBehaviour
{
    public static FinishLine instance;
    public Transform firstPoint;
    public ParticleSystem finishLineParticle;
    public List<Character> charactersInRankingStage;
    public GameObject finalCamera;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character == null) return;

        //isPlayer
        if(character.characterId == 0)
        {
            FinalPanel.instance.OpenPanel();
            finalCamera.SetActive(true);
            Player.instance.MovePlayerToPosition(firstPoint.position);
            character.Dance();
            Multiplier.instance.StartRotating(GameManager.instnace.currentLevel.levelReward);
        }
        

        foreach (Character _character in charactersInRankingStage)
        {
            _character.gameObject.SetActive(true);
            _character.animator.SetTrigger("Dance");
        }

    }
    

}


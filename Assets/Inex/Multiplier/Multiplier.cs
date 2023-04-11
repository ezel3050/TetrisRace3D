using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public static Multiplier instance;
    public Transform pointer;
    public List<float> multiplyValues;
    public TextMeshProUGUI baseRewardText, multipliedReward, claimText;

    int baseReward;
    Tween rotationTween;

    private void Awake()
    {
        instance = this;
    }

    public void StopRotating()
    {
        rotationTween.Pause();
    }

    public void StartRotating(int _baseReward)
    {
        baseReward = _baseReward;
        baseRewardText.text = baseReward.ToString();

        pointer.DORotate(new Vector3(pointer.transform.rotation.x, pointer.transform.rotation.y, -17), 0); //Reset for using it couple of times (if the multiplier is desabled and enabled again it must start from the begining)
        rotationTween = pointer.DORotate(new Vector3(pointer.transform.rotation.x, pointer.transform.rotation.y, 17), 2.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
        //rotationTween.Play();
    }
    // Red Area multiplyValue[2], Orange is multiplyValue[1] and green is 0.

    private void Update()
    {
        claimText.text = "Claim " + ReturnMultiplier() + "X";
        multipliedReward.text = Mathf.RoundToInt(baseReward * ReturnMultiplier()).ToString();
    }

    public void RewardButtonClicked()
    {
        StopRotating();
        AdManager.instance.ShowRV(() =>
        {
            UICollectableImageGenerator.Instance.SpawnItems(Input.mousePosition, MainMenu.instance.HUD.moneyUISlot.imageIcon.transform.position, () =>
            {
                MainMenu.instance.HUD.moneyUISlot.UpdateText(Mathf.RoundToInt(baseReward * ReturnMultiplier()));
            });
            
        });
    }

    public float ReturnMultiplier()
    {
        // Stupid unity Rotation/Euler/UnityUnit rotation system :W
        float rotationZ = pointer.eulerAngles.z;
        if(rotationZ > 180)
        {
            rotationZ -= 360;
            rotationZ = Mathf.Abs(rotationZ);
        }

        if (rotationZ > 10)
        {
            return multiplyValues[2];
        }

        if (rotationZ > 3.5f)
        {
            return multiplyValues[1];
        }

        else
        {
            return multiplyValues[0];
        }
    }


}
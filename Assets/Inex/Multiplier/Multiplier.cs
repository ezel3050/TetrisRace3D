using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public Transform pointer;
    public List<float> multiplyValues;

    Tween rotationTween;

    void OnEnable()
    {
        pointer.DORotate(new Vector3(pointer.transform.rotation.x, pointer.transform.rotation.y, -17), 0); //Reset for using it couple of times (if the multiplier is desabled and enabled again it must start from the begining)
        rotationTween = pointer.DORotate(new Vector3(pointer.transform.rotation.x, pointer.transform.rotation.y, 17), 2.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
    }

    public void StopRotating()
    {
        rotationTween.Pause();
    }

    public void StartRotating()
    {
        rotationTween.Play();
    }
    // Red Area multiplyValue[2], Orange is multiplyValue[1] and green is 0.

    public float ReturnMultiplier()
    {
        // Stupid unity Rotation/Euler/UnityUnit rotation system :W
        float rotationZ = pointer.eulerAngles.z;
        if(rotationZ > 180)
        {
            rotationZ -= 360;
            rotationZ = Mathf.Abs(rotationZ);
        }
        //


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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationCanvas : MonoBehaviour
{
    public static NotificationCanvas instance;
    public UIElement loadingPanel;

    private void Awake()
    {
        instance = this;
    }

}

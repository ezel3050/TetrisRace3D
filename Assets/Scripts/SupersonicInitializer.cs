using SupersonicWisdomSDK;
using UnityEngine;

public class SupersonicInitializer : MonoBehaviour
{
    void Awake()
    {
        // Subscribe
        SupersonicWisdom.Api.AddOnReadyListener(OnSupersonicWisdomReady);
        // Then initialize
        SupersonicWisdom.Api.Initialize();
    }    
                 
    void OnSupersonicWisdomReady()
    {
        // Start your game from this point
    }
}

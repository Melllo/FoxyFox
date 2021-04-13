using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class OpenDoorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(PlayerPrefs.GetInt("KEY_PICKED"));
        if (other.tag == "Player")
        { 
            if (PlayerPrefs.GetInt("KEY_PICKED") == 1)
            {
               PlayerPrefs.SetInt("KEY_PICKED", 0);
               AnalyticsResult result = Analytics.CustomEvent("Win");
               Debug.Log("Result " + result);
               SceneLoader.LoadScene(0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject respawn;
    public GameObject player;
    void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = respawn.transform.position;
        //AnalyticsResult result = Analytics.CustomEvent("Death");
    }
}

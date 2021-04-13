using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
   // private Vector3 offset;

    void Update() 
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z );
        transform.LookAt(player);
    }

}

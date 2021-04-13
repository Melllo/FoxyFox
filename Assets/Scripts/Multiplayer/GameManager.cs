using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject PlayerPrefab;
    //public GameObject SpawnPoint;
    
    private void Start() {
      //  PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPoint.transform.position, Quaternion.identity);
    }
    public void Leave() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.LogFormat("Player "+newPlayer.NickName +"entered room");
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.LogFormat("Player " + otherPlayer.NickName + "left room");
    }
}

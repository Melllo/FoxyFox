using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    public GameObject key;
    public GameObject pickedKey;
    LineRendererScript lr;
    void Start() 
    {
        lr = new LineRendererScript();
        if (PlayerPrefs.GetInt("KEY_PICKED")==0) {
            pickedKey.SetActive(false);
        } else {
            pickedKey.SetActive(true);
        }
        Debug.Log(PlayerPrefs.GetInt("KEY_PICKED"));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickedKey.SetActive(true);
            
            lr.SetEnable(true);
            Debug.Log(PlayerPrefs.GetInt("KEY_PICKED"));
            PlayerPrefs.SetInt("KEY_PICKED", 1);
            Debug.Log(PlayerPrefs.GetInt("KEY_PICKED"));
            Destroy(key);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogout : MonoBehaviour
{
    public Text text;
    public Button button;
    JSONController json;

    public void OnClickLogout()
    {
        json = new JSONController();
        json.LoadField();
        json.item.loggedIn = "false";
        json.item.Name = "None";
        json.SaveField();
        text.text = "None";
        PlayerPrefs.DeleteKey("EMAIL");
        PlayerPrefs.DeleteKey("PASSWORD");
    }
}

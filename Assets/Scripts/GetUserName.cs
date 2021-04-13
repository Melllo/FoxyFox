using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour
{
    public Text text;
    private void Start() 
    {
        text.text = PlayerPrefs.GetString("USERNAME");
    }
}

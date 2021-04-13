using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    public void StartButton() 
    {
        JSONController json = new JSONController();
        json.LoadField();
        if (json.item.loggedIn == "true")
        {
            SceneLoader.LoadScene(3);
        }
        else
        {
            SceneLoader.LoadScene(2);
        }
    }

    public void SettingButton()
    {
        SceneLoader.LoadScene(1);
    }

    public void BackButton() 
    {
        SceneLoader.LoadScene(0);
    }

    public void ExitButton() 
    {
        Application.Quit();
    }

    public void ApplyButton() 
    {
        SceneLoader.LoadScene(3);
    }
}

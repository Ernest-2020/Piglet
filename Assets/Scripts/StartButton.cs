using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameObject _menu;
  public void StartGame()
    {
        _menu = GameObject.Find("Start(Clone)");
        _menu.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _canvas;
    void Start()
    {
        Instantiate(_menu,_canvas.transform);
        Time.timeScale = 0;
    }

    
}

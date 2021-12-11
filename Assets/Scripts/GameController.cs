using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private EnemyDog _enemyDog;
    [SerializeField] private Player _playerPig;
    

    private ListExecuteObject _listExecuteObject;
    private PlayerController _playerController;
    private EnenmyController _enenmyController;

    private void Start()
    {
        _listExecuteObject = new ListExecuteObject();
        _playerController = new PlayerController(_playerPig, _joystick);
        _listExecuteObject.AddExecuteObject(_playerController);
        _enenmyController = new EnenmyController(_enemyDog);
        _listExecuteObject.AddExecuteObject(_enenmyController);
    }
    private void Update()
    {

        for (var i = 0; i < _listExecuteObject.Length; i++)
        {
            var interactiveObject = _listExecuteObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }
    }
}
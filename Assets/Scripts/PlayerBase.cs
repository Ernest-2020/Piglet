using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBase : MonoBehaviour
{
    public float _speed;
    public int HpPig;
    public Text _hpText;

    public abstract void Move(float x, float y);
    public abstract void InstantiateBomb();
    public abstract void RotatePig();


}

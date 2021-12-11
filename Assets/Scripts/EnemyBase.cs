using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyBase : MonoBehaviour,IExecute
{
    public int HpDog;
    public Text _hpDogText;
    public abstract void Execute();

}

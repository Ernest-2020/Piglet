using UnityEngine;

public class EnenmyController:IExecute
{
    private readonly EnemyBase _enemy;

    public EnenmyController(EnemyBase enemy)
    {
        _enemy = enemy;
    }
    public void Execute()
    {
        _enemy.Execute();
    }

}

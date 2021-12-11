using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDog : EnemyBase
{   [SerializeField] private List<Transform> Pivots = new List<Transform>();
    [SerializeField] PlayerBase _player;
    [SerializeField] SpriteRenderer _spriteRendererDog;
    [SerializeField] Sprite UpDog, DownDog, RightDog, LeftDog,GameOver;
    [SerializeField] GameObject _imageGameOver;
    private AIDestinationSetter _destinationSetter;
    [SerializeField] private bool _atackPlayer = false;
    private AIPath _aiPath;

    private void Start()
    {
        _aiPath = GetComponent<AIPath>();
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _hpDogText.text = HpDog.ToString();

    }
    private void Patrol()
    {
        if (_destinationSetter.target != null)
        {
            if (Vector3.Distance(_destinationSetter.target.position, transform.position) < 1 && !_atackPlayer)
            {
                _destinationSetter.target = Pivots[Random.Range(0, Pivots.Count)];
            }
        }
        else
        {
            _destinationSetter.target = Pivots[0];
        }
        
    }
    private void AttackPlayer()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < 10)
        {
            _atackPlayer = true;
            _destinationSetter.target = _player.transform;
        }
        else if (Vector3.Distance(_player.transform.position, transform.position) > 10 && _destinationSetter.target == _player)
        {
            _atackPlayer = false;
            _destinationSetter.target = null;
            return;

        }
    }
    private void RotateEnemyDog()
    {
        if (_aiPath.desiredVelocity.x >0&& _aiPath.desiredVelocity.x> _aiPath.desiredVelocity.y)
        {
            _spriteRendererDog.sprite = RightDog;
        }
        else if (_aiPath.desiredVelocity.x <0 && Mathf.Abs(_aiPath.desiredVelocity.x) > Mathf.Abs(_aiPath.desiredVelocity.y))
        {
            _spriteRendererDog.sprite = LeftDog;
        }
        if (_aiPath.desiredVelocity.y >= 0 && _aiPath.desiredVelocity.y > Mathf.Abs(_aiPath.desiredVelocity.x))
        {
            _spriteRendererDog.sprite = UpDog;
        }
        else if (_aiPath.desiredVelocity.y <0 && Mathf.Abs(_aiPath.desiredVelocity.y) > Mathf.Abs(_aiPath.desiredVelocity.x))
        {
            _spriteRendererDog.sprite = DownDog;
        }
    }
    private void Death()
    {
        if (HpDog<=0)
        {
            Time.timeScale = 0;
             HpDog = 10;
            _player.HpPig = 10;
            _player._hpText.text = _player.HpPig.ToString();
            _imageGameOver.GetComponent<Image>().sprite = GameOver;
            _imageGameOver.SetActive(true);
        }
    }

    public override void Execute()
    {
        Patrol();
        Death();
        RotateEnemyDog();
        AttackPlayer();
    }
}

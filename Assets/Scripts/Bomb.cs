using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : BombBase
{
    [SerializeField] private GameObject ExplosionEffect;
    private PlayerBase _player;
    private EnemyBase _enemy;
    private int _damageBomb = 1;

    public override void ExplosionBomb()
    {
        if (gameObject!= null)
        {
            Collider2D[] objects =  Physics2D.OverlapCircleAll(transform.position, _filedOfImpact, _layerToHit);
            foreach (Collider2D obj in objects)
            {
                if (obj.CompareTag("Player"))
                {
                    DamagePlayer();
                }
                else if(obj.CompareTag("Enemy"))
                {
                    DamageEnemy();
                }
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * _force);
            }
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            DestroyImmediate(gameObject);
        }
    }

    private void DamagePlayer()
    {
        _player = FindObjectOfType<Player>();
        _player.HpPig -= _damageBomb;
        _player._hpText.text = _player.HpPig.ToString();
    }
    private void DamageEnemy()
    {
        _enemy = FindObjectOfType<EnemyDog>();
        _enemy.HpDog -= _damageBomb;
        _enemy._hpDogText.text = _enemy.HpDog.ToString();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,_filedOfImpact);
    }

    private void Update()
    {
        Invoke("ExplosionBomb", TimeToExplosion);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : PlayerBase
{
    private Rigidbody2D _rigidbody2DPlayer;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _gameOverImage;
    [SerializeField] private EnemyBase _enemyDog;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private SpriteRenderer _spriteRendererPig;
    [SerializeField] private Sprite UpPig,DownPig,RightPig,LeftPig,GameOver;
    
    

    private void Awake()
    {
        _rigidbody2DPlayer = GetComponent<Rigidbody2D>();
        _hpText.text = HpPig.ToString();
    }
    public override void Move(float x, float y)
    {
        _rigidbody2DPlayer.velocity = new Vector2(x, y) * _speed;
       
    }

    public override void InstantiateBomb()
    {
            Instantiate(_bomb, transform.position, Quaternion.identity);
    }

    public override void RotatePig()
    {

        if (_joystick.Horizontal > 0 && _joystick.Horizontal > _joystick.Vertical)
        {
            transform.rotation = Quaternion.identity;
            _spriteRendererPig.sprite = RightPig;
            _spriteRendererPig.transform.rotation = Quaternion.identity;

        }
        else if (_joystick.Horizontal < 0 && Mathf.Abs(_joystick.Horizontal) > Mathf.Abs(_joystick.Vertical))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _spriteRendererPig.sprite = LeftPig;
            _spriteRendererPig.transform.rotation = Quaternion.identity;
        }
        if (_joystick.Vertical > 0 && _joystick.Vertical > Mathf.Abs(_joystick.Horizontal))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            _spriteRendererPig.sprite = UpPig;
            _spriteRendererPig.transform.rotation = Quaternion.identity;

        }
        else if (_joystick.Vertical < 0 && Mathf.Abs(_joystick.Vertical) > Mathf.Abs(_joystick.Horizontal))
        { 
           transform.rotation = Quaternion.Euler(0, 0, -90);
            _spriteRendererPig.transform.rotation = Quaternion.identity;
            _spriteRendererPig.sprite = DownPig;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HpPig -= 1;
            _hpText.text = HpPig.ToString();
            if (HpPig<=0)
            {
                Time.timeScale = 0;
                HpPig = 10;                
                _gameOverImage.GetComponent<Image>().sprite = GameOver;
                _gameOverImage.SetActive(true);
                
            }
            Vector2 direction = new Vector2(0,1);
            _rigidbody2DPlayer.AddForce(direction* 500);
            Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }
    }
}


using UnityEngine;

public class RestartButton:MonoBehaviour
{
    [SerializeField] Transform _startPoinPlayer,_startPointDog;
    [SerializeField] GameObject _gameOverImage;
    [SerializeField] PlayerBase _player;
    [SerializeField] EnemyBase _enemyDog;

    public void RstartGame()
    {
        _player.transform.position = _startPoinPlayer.position;
        _enemyDog.transform.position = _startPointDog.position;
        _player.HpPig = 10;
        _player._hpText.text = _player.HpPig.ToString();
        _enemyDog.HpDog = 10;
        _enemyDog._hpDogText.text = _enemyDog.HpDog.ToString();
        _gameOverImage.SetActive(false);
        Time.timeScale = 1;
        
    }
}

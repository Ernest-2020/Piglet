using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Transform _mainCamera;
    [SerializeField]
    private float _rightLimit, _leftLimit, _upperLimit, _bottomLimit;
    public CameraController(Transform player, Transform mainCamera)
    {
        _player = player;
        _mainCamera = mainCamera;
    }
    public void Update()
    {
        _mainCamera.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y,-10);
        LimitMoveCamera();
    }
    private void LimitMoveCamera()
    {
        _mainCamera.transform.position = new Vector3
            (Mathf.Clamp(_mainCamera.transform.position.x, _leftLimit, _rightLimit),
             Mathf.Clamp(_mainCamera.transform.position.y, _bottomLimit, _upperLimit),
             _mainCamera.transform.position.z);
    }
}

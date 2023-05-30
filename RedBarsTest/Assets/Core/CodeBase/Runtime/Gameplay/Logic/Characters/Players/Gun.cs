using RBT.CodeBase.Runtime.Infrastructure.Services;
using RBT.CodeBase.Runtime.Infrastructure.Services.Inputs;
using RBT.CodeBase.Runtime.Pools;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Players
{
  public class Gun : MonoBehaviour
  {
    [SerializeField] private float _rotationOffsetZ = 90f;
    [SerializeField] private float _speed = 10f;

    private Pool<CannonBall> _cannonPool;
    private IInputService _inputService;
    private bool _pause;
    private PauseService _pauseService;

    [Inject]
    private void Construct(Pool<CannonBall> cannonPool, IInputService inputService, PauseService pauseService)
    {
      _pauseService = pauseService;
      _inputService = inputService;
      _cannonPool = cannonPool;
    }

    private void Update()
    {
      Move();
      Fire();
      if (_pauseService.Pause == false)
        RotationAxisZ();
    }

    private void Move()
    {
      if (_inputService.Move != Vector2.zero)
        transform.position += new Vector3(_inputService.Move.x, 0, 0) * (_speed * Time.deltaTime);
    }

    private void Fire()
    {
      if (_inputService.Fire)
        _cannonPool.GetFreeElement(gameObject.transform.position, gameObject.transform.rotation).Fire();
    }

    private void RotationAxisZ()
    {
      Vector3 difference = Camera.main.ScreenToWorldPoint(_inputService.MousePosition) - transform.position;
      float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - _rotationOffsetZ);
    }
  }
}
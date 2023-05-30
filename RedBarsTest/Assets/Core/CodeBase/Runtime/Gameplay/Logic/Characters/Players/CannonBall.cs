using System.Collections;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Players
{
  public class CannonBall : MonoBehaviour
  {
    [SerializeField] private float _speed = 100f;

    [SerializeField] private float _timeToShutdown = 5f;

    private void Update() =>
      transform.Translate(Vector2.up * _speed * Time.deltaTime);

    private void OnCollisionEnter2D(Collision2D col) =>
      ReturnToPool();

    public void Fire() =>
      StartCoroutine(DeactivateAfterTime());

    private IEnumerator DeactivateAfterTime()
    {
      yield return new WaitForSeconds(_timeToShutdown);

      Deactivate();
    }

    private void Deactivate() =>
      ReturnToPool();

    private void ReturnToPool() =>
      gameObject.SetActive(false);
  }
}
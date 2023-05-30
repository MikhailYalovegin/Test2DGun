using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Enemys
{
  public class Enemy : CharacterBase
  {
    [SerializeField] private float _currentSpeed = 1;
    [SerializeField] private Vector2 _direc;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Awake()
    {
      _direc = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _collider2D = GetComponent<Collider2D>();
      _rigidbody2D.velocity = _direc.normalized * _currentSpeed;
    }

    private void Start() =>
      StartCoroutine(ColliderTurnOnDelay());

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Cannon Ball"))
        OnDead();

      ContactPoint2D point2D = collision.GetContact(0);
      Vector2 reflectDir = Vector2.Reflect(_direc, point2D.normal).normalized;
      _rigidbody2D.velocity = reflectDir * _currentSpeed;
      _direc = reflectDir;
    }

    protected override void OnDead()
    {
      Destroy(_rigidbody2D.gameObject);

      base.OnDead();
    }

    private IEnumerator ColliderTurnOnDelay()
    {
      _collider2D.enabled = false;
      yield return new WaitForSeconds(0.5f);
      _collider2D.enabled = true;
    }
  }
}
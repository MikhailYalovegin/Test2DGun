using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Spawn
{
  public class SpawnBorders : MonoBehaviour
  {
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _borderUp;
    [SerializeField] private GameObject _borderDown;
    [SerializeField] private GameObject _borderRight;
    [SerializeField] private GameObject _borderLeft;

    private void Awake()
    {
      _borderUp.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 1, _camera.nearClipPlane));
      _borderDown.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0, _camera.nearClipPlane));
      _borderRight.transform.position = _camera.ViewportToWorldPoint(new Vector3(1, 0.5f, _camera.nearClipPlane));
      _borderLeft.transform.position = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, _camera.nearClipPlane));
    }
  }
}
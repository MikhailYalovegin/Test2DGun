using System.Collections;
using RBT.CodeBase.Runtime.UI.Screens.Interfaces;
using UnityEngine;

namespace RBT.CodeBase.Runtime.UI.Screens
{
  public class Curtain : MonoBehaviour,
    ICurtain
  {
    private readonly WaitForSeconds _waitDelay = new(0.000001f);

    [SerializeField] private float _fadeOutSpeed = 0.05f;

    [Header("Links"), SerializeField] private Canvas _canvas;

    [SerializeField] private CanvasGroup _canvasGroup;


    private void Awake()
    {
      _canvas.enabled = false;
      _canvasGroup.alpha = 0f;
    }


    public void Show()
    {
      _canvas.enabled = true;
      _canvasGroup.alpha = 1f;
    }

    public void Hide() =>
      StartCoroutine(FadeOut());

    private IEnumerator FadeOut()
    {
      while (_canvasGroup.alpha > 0)
      {
        _canvasGroup.alpha -= _fadeOutSpeed;
        yield return _waitDelay;
      }

      _canvas.enabled = false;
    }
  }
}
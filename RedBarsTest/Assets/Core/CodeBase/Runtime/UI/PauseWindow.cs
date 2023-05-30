using UnityEngine;

namespace RBT.CodeBase.Runtime.UI
{
  public class PauseWindow : MonoBehaviour
  {
    [SerializeField] private Canvas _canvasPause;

    public void SwitchCanvasPause() =>
      _canvasPause.enabled = !_canvasPause.enabled;

    public void Initialize() =>
      _canvasPause.enabled = false;
  }
}
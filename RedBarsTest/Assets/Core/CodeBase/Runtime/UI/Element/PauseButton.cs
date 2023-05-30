using UnityEngine;
using UnityEngine.UI;

namespace RBT.CodeBase.Runtime.UI.Element
{
  public class PauseButton : MonoBehaviour
  {
    [SerializeField] private GameObject _pauseGameObject;
    [SerializeField] private Sprite _play;
    [SerializeField] private Sprite _pause;

    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    public Button Button => _button;

    public void SwitcherVisible(bool isVisible) =>
      _pauseGameObject.SetActive(isVisible);

    public void ChangeIcon(bool pause) =>
      _image.sprite = pause ? _play : _pause;
  }
}
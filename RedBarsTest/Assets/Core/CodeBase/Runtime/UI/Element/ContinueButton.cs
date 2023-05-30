using UnityEngine;
using UnityEngine.UI;

namespace RBT.CodeBase.Runtime.UI.Element
{
  public class ContinueButton : MonoBehaviour
  {
    [SerializeField] private GameObject _continueGameObject;

    [SerializeField] private Button _button;

    public Button Button => _button;

    public void SwitcherVisible(bool isVisible) =>
      _continueGameObject.SetActive(isVisible);
  }
}
using RBT.CodeBase.Runtime.Infrastructure.Tools.Interfaces;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Infrastructure.Tools
{
  public class CoroutineRunner : MonoBehaviour,
    ICoroutineRunner
  {
    private void Awake() =>
      DontDestroyOnLoad(this);
  }
}
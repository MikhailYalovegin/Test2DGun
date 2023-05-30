using System.Collections;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Infrastructure.Tools.Interfaces
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(Coroutine coroutine);
  }
}
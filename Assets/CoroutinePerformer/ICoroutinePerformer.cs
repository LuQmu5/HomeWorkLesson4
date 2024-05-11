using System.Collections;
using UnityEngine;

public interface ICoroutinePerformer
{
    Coroutine StartPerform(IEnumerator routine);
    void StopPerform(Coroutine coroutine);
}

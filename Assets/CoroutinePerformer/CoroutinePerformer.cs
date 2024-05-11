using System.Collections;
using UnityEngine;

public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
{
    public Coroutine StartPerform(IEnumerator routine) => StartCoroutine(routine);

    public void StopPerform(Coroutine coroutine) => StopCoroutine(coroutine);
}

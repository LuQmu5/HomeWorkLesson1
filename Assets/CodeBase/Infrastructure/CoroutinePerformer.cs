using System.Collections;
using UnityEngine;

public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
{
    public Coroutine StartPerform(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }

    public void StopPerform(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
    }
}

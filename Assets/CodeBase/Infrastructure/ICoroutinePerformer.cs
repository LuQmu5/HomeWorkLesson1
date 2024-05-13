using System.Collections;
using UnityEngine;

public interface ICoroutinePerformer
{
    public Coroutine StartPerform(IEnumerator coroutine);
    public void StopPerform(IEnumerator coroutine);
}

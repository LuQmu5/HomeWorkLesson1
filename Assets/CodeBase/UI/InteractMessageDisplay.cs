using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class InteractMessageDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Coroutine _coroutine;

    public void Show(string message)
    {
        _text.text = message;
        _text.gameObject.SetActive(true);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Hiding());
    }

    
    private IEnumerator Hiding()
    {
        yield return new WaitForSeconds(0.1f);

        _text.gameObject.SetActive(false);
        _coroutine = null;
    }
}

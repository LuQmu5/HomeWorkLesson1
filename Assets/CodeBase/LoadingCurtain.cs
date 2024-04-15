using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]  
public class LoadingCurtain : MonoBehaviour
{
    private const int BaseAlpha = 1;

    [SerializeField] private float _fadingOutCoeff = 0.03f;
    [SerializeField] private float _fadingOutSpeed = 0.03f;

    private CanvasGroup _curtain;
    private WaitForSeconds _fadingOutDelay;

    private void Awake()
    {
        _fadingOutDelay = new WaitForSeconds(_fadingOutSpeed);
        _curtain = GetComponent<CanvasGroup>();

        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _curtain.alpha = BaseAlpha;
    }

    public void Hide()
    {
        StartCoroutine(FadingIn());
    }

    private IEnumerator FadingIn()
    {
        while (_curtain.alpha > 0)
        {
            _curtain.alpha -= _fadingOutCoeff;

            yield return _fadingOutDelay;
        }

        gameObject.SetActive(false);
    }
}
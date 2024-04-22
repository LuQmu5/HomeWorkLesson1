using TMPro;
using UnityEngine;

public class TargetTextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Init(string target)
    {
        _text.text = target;
    }
}

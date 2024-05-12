using TMPro;
using UnityEngine;
using Zenject;

public class TargetTextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [Inject]
    public void Construct(GameManagement gameManagement)
    {
        _text.text = gameManagement.SelectedGameMode.Target;
    }
}

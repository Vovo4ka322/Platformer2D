using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _healthBar;
    [SerializeField] private TextMeshProUGUI _textMash;

    private void Start()
    {
        _textMash.text = _healthBar.Value.ToString();
    }

    private void OnEnable()
    {
        _healthBar.Changed += OnChanged;
    }

    private void OnChanged(int value)
    {
        _textMash.text = value.ToString();
    }
}

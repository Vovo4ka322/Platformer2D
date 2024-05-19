using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _healthBar;
    [SerializeField] private TextMeshProUGUI _textMash;
    [SerializeField] private Scrollbar _bar;

    private float _coefficient = 0.01f;
    private float _maxDelta = 1f;

    public void Start()
    {
        _textMash.text = _healthBar.CurrentHealth.ToString();
        _bar.size = _healthBar.CurrentHealth * _coefficient;
    }

    private void OnEnable()
    {
        _healthBar.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _healthBar.Changed -= OnChanged;
    }

    private void OnChanged(int value)
    {
        _bar.size = Mathf.MoveTowards(_bar.size, _healthBar.CurrentHealth * _coefficient, _maxDelta);
        _textMash.text = value.ToString();
    }
}

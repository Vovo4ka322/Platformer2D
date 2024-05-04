using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _healthBar;
    [SerializeField] private TextMeshProUGUI _textMash;
    [SerializeField] private Scrollbar _bar;

    private float _coefficient = 0.01f;
    private float _maxDelta = 0.005f;

    public void Start()
    {
        _textMash.text = _healthBar.Value.ToString();
        _bar.size = _healthBar.Value * _coefficient;
    }

    public void Update()
    {
        _bar.size = Mathf.MoveTowards(_bar.size, _healthBar.Value * _coefficient, _maxDelta);
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

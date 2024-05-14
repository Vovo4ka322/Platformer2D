using UnityEngine;

public class HealthPicker : MonoBehaviour
{
    [SerializeField] private Health _healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit))
            PickUp(medKit);
    }

    private void PickUp(MedKit medKit)
    {
        Destroy(medKit.gameObject);

        _healthBar.TakeHealing(medKit.Value);
    }
}

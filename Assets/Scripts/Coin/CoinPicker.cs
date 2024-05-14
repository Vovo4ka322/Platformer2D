using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)

        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            PickUp(coin);
    }

    private void PickUp(Coin coin)
    {
        _wallet.Add(coin.Value);

        Destroy(coin.gameObject);
    }
}

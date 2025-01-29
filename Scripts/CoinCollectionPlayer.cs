using UnityEngine;
using TMPro;

public class CoinCollectionPlayer : MonoBehaviour
{
   private int Coin = 0;

    public TextMeshProUGUI coinText;

   private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CoinToCollect")
        {
            Coin++;
            coinText.text = "Coin: " + Coin.ToString();
            Destroy(other.gameObject);
        }
    }
}

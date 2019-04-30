using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{
    public int currentCoins;
    public PlayerControler player;
    public Text CoinsText;

    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text = "Coins: " + Inventory.INSTANCE.Coins + " / 15";
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead == true)
        {
            UpdatePointsUI();
        }

        if (Inventory.INSTANCE.Coins <= 0)
        {
            Inventory.INSTANCE.Coins = Mathf.Clamp(Inventory.INSTANCE.Coins, 0, 1000);
        }

        currentCoins = Inventory.INSTANCE.Coins;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Inventory.INSTANCE.Coins++;
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(other.gameObject);
            UpdatePointsUI();
        }
    }

    public void UpdatePointsUI()
    {
        CoinsText.text = "Coins: " + Inventory.INSTANCE.Coins + " / 15";
    }

}

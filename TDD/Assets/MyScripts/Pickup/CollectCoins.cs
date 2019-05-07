using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoins : MonoBehaviour
{
    public int currentCoins;
    public PlayerControler player;
    public Text CoinsText;
    public int pointsneeded;
    Door door;

    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text = "Coins: " + Inventory.INSTANCE.Coins + " / " + pointsneeded;
        door = FindObjectOfType<Door>();
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

        if (Input.GetButtonDown("Open") && door.openDoor == true && Inventory.INSTANCE.Coins >= pointsneeded)
        {
            Inventory.INSTANCE.Coins = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Inventory.INSTANCE.Coins += 1;
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(other.gameObject);
            UpdatePointsUI();
        }
    }

    public void UpdatePointsUI()
    {
        CoinsText.text = "Coins: " + Inventory.INSTANCE.Coins + " / " + pointsneeded;
    }

}

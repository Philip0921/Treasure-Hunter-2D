using UnityEngine;
using UnityEngine.UI;

public class Skull : MonoBehaviour
{
    int skull;
    public PlayerControler player;
    public Text skullText;

    // Start is called before the first frame update
    void Start()
    {
        skullText.text = "Skull: " + Inventory.INSTANCE.skulls + " / 2";
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead == true)
        {
            UpdateSkullUI();
        }

        if (Inventory.INSTANCE.skulls <= 0)
        {
            Inventory.INSTANCE.skulls = Mathf.Clamp(Inventory.INSTANCE.skulls, 0, 1000);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Skull")
        {
            Inventory.INSTANCE.skulls += 1;
            //FindObjectOfType<AudioManager>().Play("PickupSkull");
            Destroy(other.gameObject);
            UpdateSkullUI();
        }
    }

    public void UpdateSkullUI()
    {
        skullText.text = "Skull: " + Inventory.INSTANCE.skulls + " / 2";
    }
}

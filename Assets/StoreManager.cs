using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
    public Button sellCarrotButton;
    public Button sellEggplantButton;
    public Button buyCarrotSeedsButton;
    public Button buyEggplantSeedsButton;

    public int carrotSellPrice;
    public int eggPlantSellPrice;
    public int carrotSeedBuyPrice;
    public int eggplantSeedBuyPrice;

    private Inventory inventory;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void Buy(int id)
    {

    }

    void Update()
    {


        buyCarrotSeedsButton.interactable = (inventory.money < carrotSeedBuyPrice);
        buyCarrotSeedsButton.interactable = (inventory.money < carrotSeedBuyPrice);


    }


}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
    public Button sellCarrotButton;
    public Button sellEggplantButton;
    public Button buyCarrotSeedsButton;
    public Button buyEggplantSeedsButton;

    public Button buyFertButton;

    public int carrotSellPrice;
    public int eggPlantSellPrice;
    public int carrotSeedBuyPrice;
    public int eggplantSeedBuyPrice;

    private Inventory inventory;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void BuyFert()
    {
        inventory.doubleSpeedFert = true;
        inventory.money -= 50;
    }

    public void Buy(int id)
    {
        if (id == 0)
        {
            inventory.carrotSeeds++;
            inventory.money -= carrotSeedBuyPrice;
        }
        else
        {
            inventory.eggplantSeeds++;
            inventory.money -= eggplantSeedBuyPrice;
        }
    }
    public void Sell(int id)
    {
        if (id == 0)
        {
            inventory.carrotAmount--;
            inventory.money += carrotSellPrice;
        }
        else
        {
            inventory.eggplantAmount--;
            inventory.money += eggPlantSellPrice;
        }
    }


    void Update()
    {


        buyCarrotSeedsButton.interactable = (inventory.money >= carrotSeedBuyPrice);
        buyEggplantSeedsButton.interactable = (inventory.money >= eggplantSeedBuyPrice);

        buyFertButton.interactable = (inventory.money >= 50 && !inventory.doubleSpeedFert);

        sellCarrotButton.interactable = (inventory.carrotAmount > 0);
        sellEggplantButton.interactable = (inventory.eggplantAmount > 0);


    }


}

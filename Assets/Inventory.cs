using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {
    public int carrotAmount;
    public int eggplantAmount;

    public int carrotSeeds;
    public int eggplantSeeds;

    public int money;
    public Text moneyText;


    public Text carrotText;
    public Text eggplantText;
    public Text carrotSeedsText;
    public Text eggplantSeedsText;


    void Start()
    {
        money = 10;
    }

    public void RemoveSeed(int id)
    {
        if (id == 0)
        {
            carrotSeeds--;
        }
        else
        {
            eggplantSeeds--;
        }
    }

    public void AddSeed(int id)
    {
        if (id == 0)
        {
            carrotSeeds++;
        }
        else
        {
            eggplantSeeds++;
        }
    }

    void Update()
    {
        moneyText.text = "$" + money;
        carrotSeedsText.text = "Carrot: " + carrotSeeds;
        eggplantSeedsText.text = "Eggplant: " + eggplantSeeds;
        carrotText.text = "Carrots: " + carrotAmount;
        eggplantText.text = "Eggplants: " + eggplantAmount;



    }

}

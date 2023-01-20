using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseSystem : MonoBehaviour
{
    static public PurchaseSystem Instance;

    [SerializeField] private Button buyGunButton;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Table table;
    private int money;
    private bool canBuy;

    private void Awake() 
    {
        if(Instance == null) //не лучшее решение, но быстрое
            Instance = this;
        AddMoney(500);
    }
    public void AddMoney(int amountMoney)
    {
        money += amountMoney;
        moneyText.text = $"Money: {money}";

        canBuy = CheckAmountMoneyToBuy(amountMoney);
    }
    
    public void Buy(int amountMoney)
    {
        canBuy = CheckAmountMoneyToBuy(amountMoney);
        if(canBuy)
        {
            RemoveMoney(amountMoney);
            table.CreateGun();
            canBuy = CheckAmountMoneyToBuy(amountMoney);
        }
    }
    private void RemoveMoney(int amountMoney)
    {
        money -= amountMoney;
        moneyText.text = $"Money: {money}";
    }
    private bool CheckAmountMoneyToBuy(int amountMoney)
    {
        if(money < amountMoney)
        {
            buyGunButton.interactable = false;
            return false;

        }
        else 
        {
            buyGunButton.interactable = true;
            return true;
        }
    }

}
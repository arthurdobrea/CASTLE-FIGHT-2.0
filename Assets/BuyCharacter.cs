using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BuyCharacter : MonoBehaviour, IService
{
    [SerializeField] public TextMeshProUGUI price;
    public UnityEvent produceNpc;

    public void BuyNpc()
    {
        float currentIncome = ServiceLocator.Instance.Get<MainIncome>().CurrentIncome;
        float priceForUnit = float.Parse(price.text);
        if (currentIncome >= priceForUnit)
        {
            ServiceLocator.Instance.Get<MainIncome>().CurrentIncome = priceForUnit;
            produceNpc?.Invoke();   
        }
    }
}

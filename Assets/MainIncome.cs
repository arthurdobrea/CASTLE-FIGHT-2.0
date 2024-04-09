using TMPro;
using UnityEngine;

public class MainIncome : MonoBehaviour, IService
{
    [SerializeField] private float incomeRate;
    [SerializeField] private TextMeshProUGUI text;

    private float counter;
    private float currentIncome;

    public float CurrentIncome
    {
        get => currentIncome;
        set
        {
            currentIncome -= value;
            text.SetText(currentIncome.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= incomeRate)
        {
            counter = 0;
            currentIncome++;
            text.SetText(currentIncome.ToString());
        }

        counter += Time.deltaTime;
    }
}
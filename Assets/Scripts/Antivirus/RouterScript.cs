using UnityEngine;
using System.Collections;

public class RouterScript : MonoBehaviour
{
    private int level = 1;
    private float moneyPerSecond = 1f;
    private int baseCost = 20;
    private float costMultiplier = 1.5f;

    void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            GameManager.AddMoney(moneyPerSecond);
            yield return new WaitForSeconds(1f);
        }
    }

    public void Upgrade()
    {
        level++;
        moneyPerSecond += 5f;
    }

    public int GetCost()
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level - 1));
    }
}

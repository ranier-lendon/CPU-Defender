using UnityEngine;
using System.Collections;

public class RouterScript : MonoBehaviour
{
    private int level = 1;
    private float moneyPerSecond = 1f;

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
        // need formula
        return 0;
    }
}

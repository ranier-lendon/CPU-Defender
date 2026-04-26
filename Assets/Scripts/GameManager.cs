using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum MalwareType 
    {
        Virus = 0,
        Trojan = 1,
        Worm = 2,
        Ransomware = 3,
        Spyware = 4
    }

    [SerializeField] private GameObject port1;   
    [SerializeField] private GameObject port2;

    [SerializeField] private static float money = 0;

    void Start()
    {
        port1.GetComponent<PortSpawn>().SpawnMalware(MalwareType.Virus);
    }

    public static void AddMoney(float amount)
    {
        money += amount;
        Debug.Log("Money: " + money);
    }
}

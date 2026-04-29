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

    [SerializeField] private static float money = 0;
    [SerializeField] private static int wave = 1;

    private WaveSystem waveSystem;

    // Introducing Malwares
    // Wave 1-5: 1*wave malwares
    // Wave 6-10: 10 malwares
    // Wave 11-15: 20 malwares
    // ...
    // Wave 46-50: 100 malwares
    // Wave 51+: 100 malwares (Malwares's HP increases by 1% each wave)

    void Start()
    {
        waveSystem = transform.GetChild(0).GetComponent<WaveSystem>();

        waveSystem.Start();
    }

    public static int GetWave()
    {
        return wave;
    }

    public static void AddMoney(float amount)
    {
        money += amount;
        Debug.Log("Money: " + money);
    }
}

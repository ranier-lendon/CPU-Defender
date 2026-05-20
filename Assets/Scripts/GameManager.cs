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

    // Game Data
    private static float money = 10;
    private static int wave = 1;

    private WaveSystem waveSystem;

    private static GameObject gameOverUI;
    private static GameObject gameUI;

    // Introducing Malwares
    // Wave 1-5: 1*wave malwares
    // Wave 6-10: 10 malwares
    // Wave 11-15: 20 malwares
    // ...
    // Wave 46-50: 100 malwares
    // Wave 51+: 100 malwares (Malwares's HP increases by 1% each wave)

    void Start()
    {
        // Ensures the game starts at normal speed
        Time.timeScale = 1f;

        // Get WaveSystem
        waveSystem = transform.GetChild(0).GetComponent<WaveSystem>();
        waveSystem.StartWaveSystem();

        // Get UI
        gameOverUI = GameObject.Find("GameOverUI");
        gameUI = GameObject.Find("GameUI");

        // Hide GameOverUI
        gameOverUI.SetActive(false);
    }

    public static int GetWave()
    {
        return wave;
    }

    public static void IncrementWave()
    {
        wave++;

        GameObject systemUI = GameObject.Find("System");
        if (systemUI != null)
        {
            var textComponent = systemUI.GetComponent<TMPro.TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "System: " + wave;
            }
        }
    }

    public static void AddMoney(float amount)
    {
        money += amount;
        Debug.Log("Money: " + money);
    }

    public static void GameOver()
    {
        // Hides GameUI
        gameUI.SetActive(false);

        // Setup Highest Wave
        int highestWave = PlayerPrefs.GetInt("HighestWave", 0);
        if (wave > highestWave)
        {
            highestWave = wave;
            PlayerPrefs.SetInt("HighestWave", highestWave);
        }
        
        // Setup GameOverUI
        gameOverUI.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "[Highest] " + (highestWave - 1) + " Systems";
        gameOverUI.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "[Defended] " + (wave - 1) + " Systems";
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}

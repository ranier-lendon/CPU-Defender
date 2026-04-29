using UnityEngine;
using System.Collections;
using static GameManager;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] ports;

    private MalwareType[] mTypes = {
        MalwareType.Virus, 
        MalwareType.Trojan, 
        MalwareType.Worm, 
        MalwareType.Ransomware, 
        MalwareType.Spyware
    };

    public void Start()
    {
        StartCoroutine(Wave());
    }

    IEnumerator Wave()
    {
        int wave = GameManager.GetWave();

        // For the first 5 waves
        if (wave <= 5) 
        {
            switch (wave)
            {
                case 1:
                    yield return SpawnWithDelay(mTypes[0], 0);
                    break;
                case 2:
                    yield return SpawnWithDelay(mTypes[0], 0);
                    yield return SpawnWithDelay(mTypes[1], 0);
                    break;
                case 3:
                    yield return SpawnWithDelay(mTypes[0], 0);
                    yield return SpawnWithDelay(mTypes[1], 0);
                    yield return SpawnWithDelay(mTypes[2], 0);
                    break;
                case 4:
                    yield return SpawnWithDelay(mTypes[0], 0);
                    yield return SpawnWithDelay(mTypes[1], 0);
                    yield return SpawnWithDelay(mTypes[2], 0);
                    yield return SpawnWithDelay(mTypes[3], 0);
                    break;
                case 5:
                    yield return SpawnWithDelay(mTypes[0], 0);
                    yield return SpawnWithDelay(mTypes[1], 0);
                    yield return SpawnWithDelay(mTypes[2], 0);
                    yield return SpawnWithDelay(mTypes[3], 0);
                    yield return SpawnWithDelay(mTypes[4], 0);
                    break;
            }
        }
        else 
        {
            int group = (wave-6)/5 + 1; // Group 1: 6-10, Group 2: 11-15 ...
            int malwareCount = Mathf.Clamp(group * 10, 10, 100); // Counts how many malware to spawn
            
            for (int i = 0; i < malwareCount; i++) 
            {
                // Spawns random malware on random ports
                int randomType = Random.Range(0, mTypes.Length);
                int randomPort = Random.Range(0, ports.Length);
                yield return SpawnWithDelay(mTypes[randomType], randomPort);
            }
        }
    }

    IEnumerator SpawnWithDelay(MalwareType type, int port)
    {
        ports[port].GetComponent<PortSpawn>().SpawnMalware(type);
        yield return new WaitForSeconds(1f);
    }
}

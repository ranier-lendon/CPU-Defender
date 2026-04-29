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

    void Start() {
        StartCoroutine(StartWave(103));
    }

    public IEnumerator StartWave(int wave)
    {
        if (wave <= 5) 
        {
            switch (wave)
            {
                case 1:
                    yield return SpawnWithDelay(mTypes[0], 1);
                    break;
                case 2:
                    yield return SpawnWithDelay(mTypes[0], 1);
                    yield return SpawnWithDelay(mTypes[1], 1);
                    break;
                case 3:
                    yield return SpawnWithDelay(mTypes[0], 1);
                    yield return SpawnWithDelay(mTypes[1], 1);
                    yield return SpawnWithDelay(mTypes[2], 1);
                    break;
                case 4:
                    yield return SpawnWithDelay(mTypes[0], 1);
                    yield return SpawnWithDelay(mTypes[1], 1);
                    yield return SpawnWithDelay(mTypes[2], 1);
                    yield return SpawnWithDelay(mTypes[3], 1);
                    break;
                case 5:
                    yield return SpawnWithDelay(mTypes[0], 1);
                    yield return SpawnWithDelay(mTypes[1], 1);
                    yield return SpawnWithDelay(mTypes[2], 1);
                    yield return SpawnWithDelay(mTypes[3], 1);
                    yield return SpawnWithDelay(mTypes[4], 1);
                    break;
            }
        }
        else 
        {
            int group = (wave-6)/5 + 1; // Group 1: 6-10, Group 2: 11-15 ...
            int malwareCount = group * 10; // Counts how many malware to spawn
            
            for (int i = 0; i < malwareCount; i++) 
            {
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

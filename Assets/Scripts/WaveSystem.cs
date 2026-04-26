using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] ports;

    IEnumerator StartWave(int wave)
    {
        if (wave <= 5) 
        {
            switch (wave)
            {
                case 1:
                    yield return SpawnWithDelay(MalwareType.Virus, 1);
                    break;
                case 2:
                    yield return SpawnWithDelay(MalwareType.Virus, 1);
                    yield return SpawnWithDelay(MalwareType.Trojan, 1);
                    break;
                case 3:
                    yield return SpawnWithDelay(MalwareType.Virus, 1);
                    yield return SpawnWithDelay(MalwareType.Trojan, 1);
                    yield return SpawnWithDelay(MalwareType.Worm, 1);
                    break;
                case 4:
                    yield return SpawnWithDelay(MalwareType.Virus, 1);
                    yield return SpawnWithDelay(MalwareType.Trojan, 1);
                    yield return SpawnWithDelay(MalwareType.Worm, 1);
                    yield return SpawnWithDelay(MalwareType.Ransomware, 1);
                    break;
                case 5:
                    yield return SpawnWithDelay(MalwareType.Virus, 1);
                    yield return SpawnWithDelay(MalwareType.Trojan, 1);
                    yield return SpawnWithDelay(MalwareType.Worm, 1);
                    yield return SpawnWithDelay(MalwareType.Ransomware, 1);
                    yield return SpawnWithDelay(MalwareType.Spyware, 1);
                    break;
            }
        }
        else
        {
            // TODO: Add malwares
            int group = (wave-6)/5 + 1; // Group 1: 6-10, Group 2: 11-15 ...
            int malwareCount = group * 10; // Counts how many malware to spawn
        }
    }

    IEnumerator SpawnWithDelay(MalwareType type, int port)
    {
        ports[port-1].SpawnMalware(type);
        yield return new WaitForSeconds(1f); // change this to your delay
    }
}

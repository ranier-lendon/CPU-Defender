using UnityEngine;
using System.Collections;
using static GameManager;

public class PortSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] malwares;
    private GameObject[] path;

    private int portNumber;
    
    void Start() {
        // Get the path from the port
        path = transform.GetComponent<PortPath>().GetWaypoints();

        // Get the port number
        portNumber = int.Parse(transform.name.Replace("Port", ""));
    }

    public void SpawnMalware(MalwareType type)
    {
        GameObject malware = malwares[(int) type];
        Transform startWaypoint = path[0].transform;

        // Spawns the malware
        GameObject malwareObject = Instantiate(malware, startWaypoint.position, malware.transform.rotation);

        // Set the port number
        malwareObject.GetComponent<EnemyScript>().portSpawned = portNumber-1;
    }
}

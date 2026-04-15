using UnityEngine;

public class PortPath : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    public GameObject[] GetWaypoints() {
        return waypoints;
    }
}

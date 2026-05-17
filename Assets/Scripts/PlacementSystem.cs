using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] towerPrefabs;

    private bool isPlacing = false;
    private int towerIndex = 0;

    GameObject ghost;

    void Start()
    {
        UpdateGhost();
    }

    void Update()
    {
        // Toggle placement mode with E key
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPlacing = !isPlacing;
        }

        if (isPlacing)
        {
            GhostTower();

            // Place tower if mouse clicked
            if (Input.GetMouseButtonDown(0)) PlaceTower();

            // Select tower type
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {   
                SelectTower(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectTower(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectTower(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectTower(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectTower(4);
            }
        }
    }

    void SelectTower(int index)
    {
        Destroy(ghost);
        towerIndex = index;
        UpdateGhost();
    }

    bool CanPlaceTower()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -1;

        // Get the actual size of tower prefab's collider
        GameObject currentPrefab = towerPrefabs[towerIndex];
        BoxCollider prefabCollider = currentPrefab.GetComponent<BoxCollider>();
        
        Vector3 halfExtents;
        if (prefabCollider != null)
        {
            // Physics.CheckBox uses "halfExtents" (half of the full size).
            // We multiply by 0.95f so towers can sit perfectly side-by-side without triggering false blocks.
            halfExtents = Vector3.Scale(prefabCollider.size, currentPrefab.transform.localScale) * 0.5f * 0.95f;
        }
        else
        {
            // Fallback size if the prefab doesn't have a BoxCollider component
            halfExtents = new Vector3(0.4f, 0.4f, 0.4f); 
        }

        // Set the Z-depth to 100f to ensure it covers the entire Z-depth of the game view.
        halfExtents.z = 100f;

        // Check a 3D box zone at the mouse position.
        // Returns true if the area is CLEAR (no Tower or Path colliders overlapping it).
        return !Physics.CheckBox(mousePosition, halfExtents, Quaternion.identity, LayerMask.GetMask("Tower", "Path"));
    }

    void PlaceTower()
    {
        if (CanPlaceTower())
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = -1;
            Instantiate(towerPrefabs[towerIndex], mousePosition, Quaternion.identity);
        } 
        else
        {
            Debug.Log("Can't place tower here");
        }
    }

    void GhostTower()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -1;

        ghost.transform.position = mousePosition;
    }

    void UpdateGhost()
    {
        // Instantiate a new tower as a ghost at the mouse position
        ghost = Instantiate(towerPrefabs[towerIndex], transform.position, Quaternion.identity);

        // Disable all colliders on the ghost tower
        Collider[] colliders = ghost.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }

        // Disable all scripts on the ghost tower
        MonoBehaviour[] scripts = ghost.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
        
        // Get the sprite renderer of the ghost tower
        SpriteRenderer spriteRenderer = ghost.GetComponent<SpriteRenderer>();

        // Make the ghost tower semi-transparent
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }
}

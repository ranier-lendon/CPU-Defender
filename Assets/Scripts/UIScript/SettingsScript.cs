using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private GameObject _settingsUI;
    
    public void ShowSettings() {
        _settingsUI.SetActive(true);
    }

    public void HideSettings() {
        _settingsUI.SetActive(false);
    }
}

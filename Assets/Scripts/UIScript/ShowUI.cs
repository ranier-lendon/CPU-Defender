using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    
    public void DisplayUI() 
    {
        _ui.SetActive(true);
    }

    public void HideUI() 
    {
        _ui.SetActive(false);
    }
}

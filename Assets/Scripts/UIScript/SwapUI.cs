using UnityEngine;

public class SwapUI : MonoBehaviour
{
    [SerializeField] private GameObject _currentUI;
    [SerializeField] private GameObject _otherUI;

    public void Swap() 
    {
        _currentUI.SetActive(false);
        _otherUI.SetActive(true);
    }
}

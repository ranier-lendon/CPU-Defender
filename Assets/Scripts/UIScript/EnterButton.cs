using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterButton : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Game");
    }
}

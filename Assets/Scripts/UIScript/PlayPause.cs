using UnityEngine;

public class PlayPause : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}

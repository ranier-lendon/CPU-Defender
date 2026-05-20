using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            Load();
        }
        else
        {
            _musicSlider.value = 1f;
            _soundSlider.value = 1f;

            ChangeMusicVolume();
            ChangeSoundVolume();
        }
    }

    public void ChangeMusicVolume()
    {
        float volume = Mathf.Log10(Mathf.Max(_musicSlider.value, 0.0001f)) * 20;
        mixer.SetFloat("MusicVolume", volume);
        Save();
    }

    public void ChangeSoundVolume()
    {
        float volume = Mathf.Log10(Mathf.Max(_soundSlider.value, 0.0001f)) * 20;
        mixer.SetFloat("SoundVolume", volume);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
        PlayerPrefs.SetFloat("soundVolume", _soundSlider.value);
    }

    private void Load()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
}
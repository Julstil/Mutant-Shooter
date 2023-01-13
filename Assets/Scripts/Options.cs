using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer master;
    public AudioMixerGroup music;
    public AudioMixerGroup sfx;
    public Dropdown fsDrop;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Text masterVolumeText;
    public string masterParameter = "masterVol";
    public float masterVolume;
    public float temp;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;


    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(masterParameter);
        musicSlider.value = PlayerPrefs.GetFloat("musicvolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxvolume");
        int selectedScreenMode = PlayerPrefs.GetInt("SelectedScreenMode", 0);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    // Update is called once per frame
    void Update()
    {
        temp = (Mathf.Round(masterSlider.value + 100));
        masterVolumeText.text = "Master Volume: " + temp + "%";
        
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetScreenMode()
    {
        if (fsDrop.options[fsDrop.value].text == "Fullscreen")
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            PlayerPrefs.SetInt("selectedScreenMode", 0);
        }
        else if (fsDrop.options[fsDrop.value].text == "Windowed")
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            PlayerPrefs.SetInt("selectedScreenMode", 3);
        }
        else if (fsDrop.options[fsDrop.value].text == "Window (borderless)") 
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            PlayerPrefs.SetInt("selectedScreenMode", 1);
        }
    }

    public void SetMusicLevel(float musicLvl)
    {

        music.audioMixer.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("musicvolume", musicSlider.value);

    }

    public void SetSfxLevel(float sfxLvl)
    {

        sfx.audioMixer.SetFloat("sfxVol", sfxSlider.value);
        PlayerPrefs.SetFloat("sfxvolume", sfxSlider.value);

    }
    public void SetMasterLevel(float masterLvl)
    {
        master.SetFloat("masterVol", masterSlider.value);
        PlayerPrefs.SetFloat(masterParameter, masterSlider.value);

    }
    





}

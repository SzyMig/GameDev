using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class menu_script : MonoBehaviour
{
    public AudioMixer audioMixer;
    // TExt mesh pro dropdown
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public Slider volumeSlider;
    float volume;
    public TMPro.TMP_Dropdown aaDropdown;
    public TMPro.TMP_Dropdown textureDropdown;
    float currentVolume;

    public void start(){
        volumeSlider.value = currentVolume;
        // set default resolutions and quality settings
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        int currentAAIndex = 0;
        int currentTextureIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            if (resolutions[i].width == Screen.width &&
            resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        aaDropdown.value = currentAAIndex;
        aaDropdown.RefreshShownValue();
        textureDropdown.value = currentTextureIndex;
        textureDropdown.RefreshShownValue();
        

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        currentVolume = volume;
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void setAA(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
    }

    public void setTexture(int textureIndex)
    {
        QualitySettings.globalTextureMipmapLimit = textureIndex;
    }

}
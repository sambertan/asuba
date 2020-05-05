using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options_menu : MonoBehaviour
{
 /*   public AudioMixer audiomixer;
    Resolution[] resolutions;
    public Dropdown resdropdown;
   public void SetVolume( float volume)
    {
        audiomixer.SetFloat("Volume",volume);
    }
    public void SetQuality(int quality_index)
    {
        QualitySettings.SetQualityLevel(quality_index);
    }
    public void FullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
     void Start()
    {
        resolutions = Screen.resolutions;
        resdropdown.ClearOptions();
        List<string> options = new List<string>();
        int resindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                resindex = i;
            }
        }
        resdropdown.AddOptions(options);
        resdropdown.value = resindex;
        resdropdown.RefreshShownValue();
    }

    public void Setres(int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    */
}

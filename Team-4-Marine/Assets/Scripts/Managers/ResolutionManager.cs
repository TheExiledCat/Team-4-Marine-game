using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{

    Resolution[] m_Resolutions;

    [SerializeField]
    private TMPro.TMP_Dropdown m_ResolutionDropdown;
    // Start is called before the first frame update
    void Start()
    {
        m_Resolutions = Screen.resolutions;

        m_ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < m_Resolutions.Length; i++)
        {
            string option = m_Resolutions[i].width + " X " + m_Resolutions[i].height;
            options.Add(option);

            if (m_Resolutions[i].width == Screen.currentResolution.width &&
                m_Resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        m_ResolutionDropdown.AddOptions(options);
        m_ResolutionDropdown.value = currentResolutionIndex;
        m_ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = m_Resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

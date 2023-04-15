using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    private RectTransform currentPanel;
    [SerializeField]
    private RectTransform mainPanel;
    [SerializeField]
    private RectTransform difficultyPanel;
    [SerializeField]
    private RectTransform creditsPanel;
    [SerializeField]
    private RectTransform settingsPanel;
    
    [SerializeField] 
    private Button soundButton;
    [SerializeField]
    private Button musicButton;

    private bool isSoundOn;
    private bool isMusicOn;
    
    private void Awake()
    {
        // Set player prefs.
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    private void Start()
    {
        isSoundOn = Convert.ToBoolean(PlayerPrefs.GetInt("Sound", 1));
        isMusicOn = Convert.ToBoolean(PlayerPrefs.GetInt("Music", 1));

        if (!isSoundOn)
        {
            soundButton.image.sprite = Resources.Load<Sprite>("Sprites/Sound Muted Icon");
        }

        if (!isMusicOn)
        {
            musicButton.image.sprite = Resources.Load<Sprite>("Sprites/Music Muted Icon");
        }
    }

    public void BackToTheMenuButton()
    {
        currentPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }
    
    public void PlayButton()
    {
        mainPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(true);
        currentPanel = difficultyPanel;
    }
    
    public void SettingsButton()
    {
        mainPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(true);
        currentPanel = settingsPanel;
    }
    
    public void CreditsButton()
    {
        mainPanel.gameObject.SetActive(false);
        creditsPanel.gameObject.SetActive(true);
        currentPanel = creditsPanel;
    }

    public void SoundButton()
    {
        // Change button image
        // toggle between on and off sounds
        if (isSoundOn)
        {
            // Switch ON to OFF
            PlayerPrefs.SetInt("Sound", 0);
            soundButton.image.sprite = Resources.Load<Sprite>("Sprites/Sound Muted Icon");
        }
        else
        {
            // Switch OFF to ON
            PlayerPrefs.SetInt("Sound", 1);
            soundButton.image.sprite = Resources.Load<Sprite>("Sprites/Sound Icon");
        }
        // Toggle isSoundOn variable when clicked.
        isSoundOn = !isSoundOn;
    }

    public void MusicButton()
    {
        if (isMusicOn)
        {
            PlayerPrefs.SetInt("Music", 0);
            musicButton.image.sprite = Resources.Load<Sprite>("Sprites/Music Muted Icon");
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            musicButton.image.sprite = Resources.Load<Sprite>("Sprites/Music Icon");
        }

        isMusicOn = !isMusicOn;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) Debug.Log(isSoundOn);
    }
}

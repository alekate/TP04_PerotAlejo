using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [Header("Score")]
    public TMP_Text scoreText;

    [Header("AudioSetting")]
    [SerializeField] private AudioMixer myMixer;

    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;

    [Header("PlayerGameData")]
    [SerializeField] private InitialGameData gameData;
    
    [Header("Pause")]
    private bool isPaused = false;
    public GameObject pausePanel;

    [Header("CurrentVelocity")]
    public float currentVelocity;

    void Update()
    {
        if (Input.GetKeyDown(gameData.pause))
        {
            if (!isPaused)
            {
                currentVelocity = Time.timeScale;
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                isPaused = true;
            }
            else
            {
                Time.timeScale = currentVelocity;
                pausePanel.SetActive(false);
                isPaused = false;
            }
        }
    }

    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
    }
    public void TextImport(int points)
    {
        scoreText.text = points.ToString();
    }
}

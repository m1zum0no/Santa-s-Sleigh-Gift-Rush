using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance;
    public AudioSource[] soundEffects;
    public AudioSource[] music;
    private int currentMusic = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            music[0].Play();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
            if (!music[currentMusic].isPlaying)
            {
            // Переходим к следующему треку
            currentMusic++;
                if (currentMusic >= music.Length)
                {
                currentMusic = 0; // Начинаем сначала, если достигли конца массива
                }
                music[currentMusic].Play(); // Играем следующий трек
            }
    }
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }
}
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
            // ��������� � ���������� �����
            currentMusic++;
                if (currentMusic >= music.Length)
                {
                currentMusic = 0; // �������� �������, ���� �������� ����� �������
                }
                music[currentMusic].Play(); // ������ ��������� ����
            }
    }
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }
}
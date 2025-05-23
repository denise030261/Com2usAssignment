using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private AudioSource bgmSource;
    float bgmVolume = 0.5f;

    public void PlayBGM(string name)
    {
        AudioClip bgmClip = Resources.Load<AudioClip>("Music/BGM/" + name);
        if (bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.volume = bgmVolume;
            bgmSource.Play();
        }
        else
        {
            Debug.LogError("BGM�� ������ �ʽ��ϴ�");
        }
    }

    public void ContinueBGM()
    {
        bgmSource.volume = 0.5f;
        bgmVolume = 0.5f;
    }

    public void StopBGM()
    {
        bgmSource.volume = 0;
        bgmVolume = 0;
    }

}

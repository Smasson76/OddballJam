using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip mainMusic;
    private AudioSource mainMusicSource;

    public AudioClip[] clips;
    public int maxSources = 5;

    private static AudioSource[] sources;
    private static int index = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        sources = new AudioSource[maxSources];

        for (int i = 0; i < maxSources; i++)
        {
            GameObject g = new GameObject("SFX" + i);
            AudioSource s = g.AddComponent<AudioSource>();
            sources[i] = s;
        }

        GameObject a = new GameObject();
        mainMusicSource = a.AddComponent<AudioSource>();
        PlayMainMusic();
    }

    public static void PlayMainMusic()
    {
        instance.mainMusicSource.clip = instance.mainMusic;
        instance.mainMusicSource.Play();
        instance.mainMusicSource.loop = true;
    }

    public static void Play(string clipName)
    {
        AudioClip clip = null;
        for (int i = 0; i < instance.clips.Length; i++)
        {
            if (instance.clips[i].name == clipName)
            {
                clip = instance.clips[i];
                break;
            }
        }

        if (clip != null)
        {
            sources[index].clip = clip;
            sources[index].Play();
            index = (index + 1) % instance.maxSources;
        }
    }
}

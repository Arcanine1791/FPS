using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Sound
{
    music,
    coinPickUp,
    healthPickup,
    attack,
    playerWalk,
    playerJump
}

[System.Serializable]
public class SoundAudioClip
{
    public Sound soundType;
    public AudioClip audioClip;
    public AudioMixerGroup audioMixerGroup;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private SoundAudioClip[] soundAudioClips;

    private Dictionary<Sound, float> soundTimerDictionary;

    private GameObject oneShotGameObject;
    private AudioSource oneShotAudioSource;
    private float backGroundVolume;
    private float sfxVolume;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        backGroundVolume = 1;
    }

    private void Start()
    {
        //PlayBackgroundMusic();
        Initialize();
    }

    public void PlayBackgroundMusic()
    {
        GameObject bg_sound = new GameObject("Background music");
        AudioSource audioSource = bg_sound.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(Sound.music);
        audioSource.outputAudioMixerGroup = GetAudioMixerSound(Sound.music);
        audioSource.volume = backGroundVolume;
        audioSource.loop = true;
        audioSource.Play();

        DontDestroyOnLoad(bg_sound);
    }

    private void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.playerWalk] = 0;
    }

    public void PlaySound(Sound sound, Vector3 position)
    {
        if(CanPlaySound(sound))
        {
            GameObject soundObj = new GameObject("Sound");
            AudioSource audioSource = soundObj.AddComponent<AudioSource>();
            soundObj.transform.position = position;
            audioSource.clip = GetAudioClip(sound);
            audioSource.outputAudioMixerGroup = GetAudioMixerSound(sound);
            audioSource.maxDistance = 100f;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.dopplerLevel = 0f;

            float loadedSfxValue = PlayerPrefs.GetFloat("sfx");
            sfxVolume = PlayerPrefs.HasKey("sfx") ? loadedSfxValue : 1;

            audioSource.volume = sfxVolume;
            audioSource.Play();
            Destroy(soundObj, audioSource.clip.length);
        }
    }

    public void PlaySound(Sound sound)
    {
        if(CanPlaySound(sound))
        {
            if(oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
            oneShotAudioSource.outputAudioMixerGroup = GetAudioMixerSound(sound);

            float loadedSfxValue = PlayerPrefs.GetFloat("sfx");
            sfxVolume = PlayerPrefs.HasKey("sfx") ? loadedSfxValue : 1;

            oneShotAudioSource.volume = sfxVolume;
        }
    }

    private bool CanPlaySound(Sound sound)
    {
        switch(sound)
        {
            default:
                return true;
            case Sound.playerWalk:
                if(soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimerPlayed = soundTimerDictionary[sound];
                    float playerMaxTimer = 0.5f;
                    if(lastTimerPlayed + playerMaxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }

        }
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        foreach(SoundAudioClip soundClip in soundAudioClips)
        {
            if(soundClip.soundType == sound)
            {
                return soundClip.audioClip;
            }
        }

        Debug.LogError("Sound " + sound + " not found");
        return null;
    }

    private AudioMixerGroup GetAudioMixerSound(Sound sound)
    {
        foreach(SoundAudioClip soundClip in soundAudioClips)
        {
            if(soundClip.soundType == sound)
            {
                return soundClip.audioMixerGroup;
            }
        }

        Debug.LogError("Sound " + sound + " not found");
        return null;
    }
}
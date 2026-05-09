using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sounds")]
    public Sound[] musicSounds;
    public Sound[] sfxSounds;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Loop SFX Sources")]
    public AudioSource walkingSource;
    public AudioSource flamethrowerSource;
    public AudioSource burningSource;

    [Header("Scene Music Settings")]
    public SceneMusic[] sceneMusicList;

    private string currentMusicName = "";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        PlayMusicForCurrentScene();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();

        StopWalkingLoop();
        StopFlamethrowerLoop();
        StopBurningLoop();
    }

    private void PlayMusicForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        for (int i = 0; i < sceneMusicList.Length; i++)
        {
            if (sceneMusicList[i].sceneName == sceneName)
            {
                PlayMusic(sceneMusicList[i].musicName);
                return;
            }
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Music not found: " + name);
            return;
        }

        if (currentMusicName == name && musicSource.isPlaying)
        {
            return;
        }

        currentMusicName = name;

        musicSource.clip = sound.clip;
        musicSource.volume = sound.volume;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.LogWarning("SFX not found: " + name);
            return;
        }

        sfxSource.PlayOneShot(sound.clip, sound.volume);
    }

    private void PlayLoopSFX(AudioSource source, string name)
    {
        if (source == null) return;

        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Loop SFX not found: " + name);
            return;
        }

        if (source.isPlaying && source.clip == sound.clip)
        {
            return;
        }

        source.clip = sound.clip;
        source.volume = sound.volume;
        source.loop = true;
        source.Play();
    }

    private void StopLoopSFX(AudioSource source)
    {
        if (source == null) return;

        if (source.isPlaying)
        {
            source.Stop();
        }
    }

    public void PlayWalkingLoop()
    {
        PlayLoopSFX(walkingSource, "walking");
    }

    public void StopWalkingLoop()
    {
        StopLoopSFX(walkingSource);
    }

    public void PlayFlamethrowerLoop()
    {
        PlayLoopSFX(flamethrowerSource, "flamethrower");
    }

    public void StopFlamethrowerLoop()
    {
        StopLoopSFX(flamethrowerSource);
    }

    public void PlayBurningLoop()
    {
        PlayLoopSFX(burningSource, "burning");
    }
    public void StopBurningLoop()
    {
        StopLoopSFX(burningSource);
    }
}
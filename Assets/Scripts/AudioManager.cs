using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private AudioSource musicSource;
    public static AudioManager instance;
    private float musicVolume = 1f;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("Start called");
        StartCoroutine(InitializeAudio());
    }

    private IEnumerator InitializeAudio()
    {
        yield return new WaitForEndOfFrame(); // wait for audio sources to be initialized

        FindMusicSource();
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded called");
        StartCoroutine(InitializeAudio());
    }

    private void FindMusicSource()
    {
        if (musicSource == null)
        {
            musicSource = GetComponentInChildren<AudioSource>();
            if (musicSource == null)
            {
                Debug.LogWarning("AudioSource not found in the scene.");
            }
        }
    }

    public void AssignSlider()
    {
        StartCoroutine(AssignSliderCoroutine());
    }

    private IEnumerator AssignSliderCoroutine()
    {
        yield return new WaitForEndOfFrame(); // wait for one frame to ensure the slider is present in the scene

        Slider slider = FindObjectOfType<Slider>();
        if (slider != null)
        {
            slider.value = musicVolume;
            slider.onValueChanged.RemoveAllListeners(); // prevent duplicate listeners
            slider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogWarning("Slider not found in the scene.");
        }
    }

    private void SetVolume(float volume)
    {
        musicVolume = volume;
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
}

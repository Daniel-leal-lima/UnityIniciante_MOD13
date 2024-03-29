using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    struct AudioGroups
    {
        public string label;
        public Audio[] audios;
    }

    [System.Serializable]
    struct Audio
    {
        public string name;
        public AudioSource audioSource;
    }

    [SerializeField] List<AudioGroups> audioList;

    public static AudioManager instance;

    public static string IDBACKGROUNDMUSIC = "BG";
    public const string IDSLICE = "Slice";
    public const string IDMISS = "Miss";
    public const string IDBOXBREAK = "Box-Break";


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        PlayAudio(IDBACKGROUNDMUSIC);
    }

    public void PlayAudio(AudioSource audioSource, Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, pos);
    }

    public void PlayAudio(string nameOfAudio)
    {
        PlayAudio(GetAudioSource(nameOfAudio), Camera.main.transform.position);
    }
    public void SetVolume(string label, float volume)
    {
        Audio[] audios = audioList[audioList.FindIndex(x => x.label == label)].audios;

        foreach (var item in audios)
        {
            item.audioSource.volume = volume;
        }
    }

    private AudioSource GetAudioSource(string name)
    {
        IEnumerable<AudioSource> audioQuery = from audioGroups in audioList
                                              from audios in audioGroups.audios
                                              from audioName in audios.name
                                              where audios.name == name
                                              select audios.audioSource;

        AudioSource audioSource = audioQuery.FirstOrDefault();


        return audioSource;

    }

}
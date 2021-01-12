using System;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer mixer;
    public Sound[] sounds;

    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.outputAudioMixerGroup = s.AudiOutput;

        }
    }

    //call this function anywhere to play sound;
    public void PlaySound(string name)
    {
       Sound s= Array.Find(sounds, Sound => Sound.name == name);
      

        if (s == null)
        {
            Debug.LogError("Sound:" + name + "not found");
            return;
        }
            
        s.source.Play();
        
    }

    


    private void Start()
    {
        
       
    }


  

}

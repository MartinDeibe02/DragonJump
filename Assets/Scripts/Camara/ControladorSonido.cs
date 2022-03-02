using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    public static ControladorSonido instance { get; private set; }
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(instance==null){
            instance = this;
        DontDestroyOnLoad(gameObject);
        }else if(instance != null && instance != this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void Play(AudioClip _audio)
    {
        audio.PlayOneShot(_audio);
    }
}

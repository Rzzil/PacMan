using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgm;
    [SerializeField]
    private AudioSource soundEffect;

    [SerializeField]
    private List<AudioClip> bgmList;

    [SerializeField]
    private List<AudioClip> soundEffectList;

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(bgmList[0]);
        Invoke("StopBGM", 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(!bgm.isPlaying)
        {
            PlayBGM(bgmList[1]);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if(bgm.clip!=clip)
        {
            bgm.clip = clip;
            bgm.Play();
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {

    }

    public void StopBGM()
    {
        bgm.Stop();
    }
}

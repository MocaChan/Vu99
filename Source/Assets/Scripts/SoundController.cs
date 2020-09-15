using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip brokenGlass, collison;
    public AudioClip[] Theme;
    AudioSource au;
    void Start()
    {
        au = GetComponent<AudioSource>();
        au.clip = Theme[0];
        au.Play();
        au.volume = 1f;
    }

    void Update()
    {
        if (GameCache.IsPlaying == true)
        {
            if (GameCache.actiCrusher == true)
            {
                au.PlayOneShot(brokenGlass, 0.7f);
                GameCache.actiCrusher = false;
            }
            if (GameCache.actiCollision == true)
            {
                au.PlayOneShot(collison, 0.7f);
                GameCache.actiCollision = false;
            }
        }
    }
}

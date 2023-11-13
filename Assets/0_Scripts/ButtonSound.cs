using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public static ButtonSound instance;

    public AudioClip clickSFX, moveSFX;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayMove()
    {
        GetComponent<AudioSource>().PlayOneShot(moveSFX);
    }
    public void PlayClick()
    {
        GetComponent<AudioSource>().PlayOneShot(clickSFX);
    }
}

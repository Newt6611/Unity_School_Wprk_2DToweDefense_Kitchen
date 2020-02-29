using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    PlaceToolSound, MoneyNotEnoughSound, OpenPageSound,
    ClosePageSound, Stop, Win, Lose
}

public class AudioManager : MonoBehaviour
{
    public static AudioSource audio;

    public static AudioClip placeToolSound;
    public static AudioClip moneyNotEoungh;
    public static AudioClip openPageSound;
    public static AudioClip closePageSound;
    public static AudioClip loseSound;
    public static AudioClip winSound;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        placeToolSound = Resources.Load<AudioClip>("place tool sound");
        moneyNotEoungh = Resources.Load<AudioClip>("money not enough");
        openPageSound = Resources.Load<AudioClip>("open page");
        closePageSound = Resources.Load<AudioClip>("close page");
        winSound = Resources.Load<AudioClip>("win");
        loseSound = Resources.Load<AudioClip>("lose");
    }

    public static void Play(Sound sound)
    {
        switch (sound)
        {
            case Sound.PlaceToolSound:
                audio.PlayOneShot(placeToolSound);
                break;
            case Sound.MoneyNotEnoughSound:
                audio.PlayOneShot(moneyNotEoungh);
                break;
            case Sound.OpenPageSound:
                audio.PlayOneShot(openPageSound);
                break;
            case Sound.ClosePageSound:
                audio.PlayOneShot(closePageSound);
                break;
            case Sound.Win:
                audio.PlayOneShot(winSound);
                break;
            case Sound.Lose:
                audio.PlayOneShot(loseSound);
                break;
        }
    }
}

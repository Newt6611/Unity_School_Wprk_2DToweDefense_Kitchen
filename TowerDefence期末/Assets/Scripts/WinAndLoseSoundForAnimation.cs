using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLoseSoundForAnimation : MonoBehaviour
{
    public void PlayWinSound()
    {
        AudioManager.Play(Sound.Win);
    }

    public void PlayLoseSoun()
    {
        AudioManager.Play(Sound.Lose);
    }
}

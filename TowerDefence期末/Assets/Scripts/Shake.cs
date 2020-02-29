using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAni;
    public Animator notEnoughMoneyAni;

    public void CameraShake()
    {
        camAni.SetTrigger("shake");
    }

    public void ShowNotEnoughMoney()
    {
        notEnoughMoneyAni.SetTrigger("show");
    }
}

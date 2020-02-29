using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float startLifeTime;

    void Update()
    {
        if (startLifeTime <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            startLifeTime -= Time.deltaTime;
        }
    }
}

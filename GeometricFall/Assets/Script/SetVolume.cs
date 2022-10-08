using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume") - 0.2f;
    }
}

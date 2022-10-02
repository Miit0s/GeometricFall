using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    //Le volume doit être compris entre 0 et 1
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangerMasterVolume(val));
    }
}

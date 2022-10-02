using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioClip clickButton;

    public void Click()
    {
        SoundManager.Instance.PlaySound(clickButton);
    }
}

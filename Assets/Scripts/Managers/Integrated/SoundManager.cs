using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource; //효과음 오디오 변수
    public AudioSource bgmSource; //배경음 오디오 변수

    private Dictionary<Enum, AudioClip> clip = new Dictionary<Enum, AudioClip>(); //key값인 Enum을 넣으면 value로 AudioCiip 호출

    public void PlaySFX(SFXType type)
    {

    }

    public void Init()
    {

    }
}

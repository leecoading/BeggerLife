using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource; //ȿ���� ����� ����
    public AudioSource bgmSource; //����� ����� ����

    private Dictionary<Enum, AudioClip> clip = new Dictionary<Enum, AudioClip>(); //key���� Enum�� ������ value�� AudioCiip ȣ��

    public void PlaySFX(SFXType type)
    {

    }

    public void Init()
    {

    }
}

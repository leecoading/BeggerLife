using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource; //ȿ���� ����� ����
    public AudioSource bgmSource; //����� ����� ����

    private Dictionary<Enum, AudioClip> clip = new Dictionary<Enum, AudioClip>(); //key���� Enum�� ������ value�� AudioCiip ȣ��



    public void PlaySFX(SFXType type)
    {
        //sfxSource = value,  clip[type] = key��
        sfxSource.PlayOneShot(clip[type]);
    }

    public void PlayBGM(BGMType type)
    {
        if(bgmSource.clip == clip[type])
        {
            if (bgmSource.clip == clip[type])
                return;

            bgmSource.clip = clip[type];
            bgmSource.Play();
        }
    }

    public void SetVolume(string name, float volume)
    {
        if(name == "BGM")
        {
            bgmSource.volume = volume;
            PlayerPrefs.SetFloat("BGM",volume);
        }
        else if (name == "SFX")
        {
            sfxSource.volume = volume;
            PlayerPrefs.SetFloat("SFX",volume );
        }
    }

    /// <summary>
    /// �� �ε� �� ȣ�����ִ� �Լ�
    /// </summary>
    public void OnLoadCompleted(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.name)
        {
            //���� �ش� scene�϶� bgm clip�� null�̰� bgm clip�� clip�� enum�� �ش� scene�� �ƴ϶��
            case "SeoulScene":
                if(bgmSource.clip == null || bgmSource.clip != clip[BGMType.Seoul])
                {
                    bgmSource.clip = clip[BGMType.Seoul];
                    bgmSource.Play();
                }
                break;

            case "EarthScene":
                if (bgmSource.clip == null || bgmSource.clip != clip[BGMType.Earth])
                {
                    bgmSource.clip = clip[BGMType.Earth];
                    bgmSource.Play();
                }
                break;

            case "SloarSystemScene":
                if (bgmSource.clip == null || bgmSource.clip != clip[BGMType.SolarSystem])
                {
                    bgmSource.clip = clip[BGMType.SolarSystem];
                    bgmSource.Play();
                }
                break;

            case "GalaxyScene":
                if (bgmSource.clip == null || bgmSource.clip != clip[BGMType.Galaxy])
                {
                    bgmSource.clip = clip[BGMType.Galaxy];
                    bgmSource.Play();
                }
                break;

            case "SpaceScene":
                if (bgmSource.clip == null || bgmSource.clip != clip[BGMType.Space])
                {
                    bgmSource.clip = clip[BGMType.Space];
                    bgmSource.Play();
                }
                break;

            case "MultiVerseScene":
                if (bgmSource.clip == null || bgmSource.clip != clip[BGMType.Multiverse]) 
                {
                    bgmSource.clip = clip[BGMType.Multiverse];
                    bgmSource.Play();
                }
                break;
        }
    }

    /// <summary>
    /// ������ SoundManager �ڽ����� SFX�� BGM�� �־��ִ� �Լ�
    /// </summary>
    public void Init()
    {
        GameObject sfxGameObject = new GameObject("SFX");
        GameObject bgmGameObject = new GameObject("BGM");

        sfxGameObject.transform.SetParent(transform);
        bgmGameObject.transform.SetParent(transform);

        sfxSource = sfxGameObject.AddComponent<AudioSource>();
        bgmSource = bgmGameObject.AddComponent<AudioSource>();



        var sfxLoad = Resources.LoadAll<AudioClip>("Sounds/SFX");
        ClipLoad<SFXType>(sfxLoad);

        var bgmLoad = Resources.LoadAll<AudioClip>("Sounds/BGM");
        ClipLoad<BGMType>(bgmLoad);

        bgmSource.playOnAwake = false;
        bgmSource.loop = true;
        bgmSource.volume = 0.3f;

        sfxSource.playOnAwake = false;
        sfxSource.volume = 1f;

        bgmSource.volume = PlayerPrefs.GetFloat("BGM", 1);
        sfxSource.volume = PlayerPrefs.GetFloat("SFX", 1);

        SceneLoadManager.OnLoadCompleted(OnLoadCompleted);


    }

    public void ClipLoad<T>(AudioClip[] arr) where T : Enum
    {
        for(int i = 0;  i < arr.Length; i++)
        {
            try
            {
                T type = (T)Enum.Parse(typeof(T), arr[i].name);
                clip.Add(type, arr[i]);
            }
            catch
            {
                Debug.LogWarning("Need Enum : " + arr[i].name);
            }
        }
    }
}

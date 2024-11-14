using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour,IManager
{
    public AudioSource sfxSource; //효과음 오디오 변수
    public AudioSource bgmSource; //배경음 오디오 변수

    private Dictionary<Enum, AudioClip> clip = new Dictionary<Enum, AudioClip>(); //key값인 Enum을 넣으면 value로 AudioCiip 호출



    public void PlaySFX(SFXType type)
    {
        //sfxSource = value,  clip[type] = key값
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
    /// 씬 로드 시 호출해주는 함수
    /// </summary>
    public void OnLoadCompleted(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.name)
        {
            //만약 해당 scene일때 bgm clip이 null이고 bgm clip과 clip의 enum이 해당 scene이 아니라면
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
    /// 생성된 SoundManager 자식으로 SFX와 BGM을 넣어주는 함수
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

using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.Build.Content;
using UnityEngine;

public sealed class Managers : MonoBehaviour
{
    //Managers 인스턴스
    private static Managers instance;

    //생성된 Manager들 리턴값
    public static UIManager UIManager { get { return instance.uiManager; } }
    public static GameManager GameManager { get { return instance.gameManager; } }


    //생성된 Manager들 인스턴스
    private UIManager uiManager;
    private GameManager gameManager;



    //생명주기에서 awake보다 우선 실행
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //Managers초기화 함수
    private static void Init()
    {
        Screen.SetResolution(760, 1280, false);

        GameObject gameObject = new GameObject("Managers");
        instance = gameObject.AddComponent<Managers>();
        DontDestroyOnLoad(gameObject);

        instance.uiManager = CreateManager<UIManager>(gameObject.transform);
    }




    //Manager들 hierarchy에 생성해주는 함수
    private static T CreateManager<T>(Transform parent) where T : Component, IManager
    {
        GameObject gameObject = new GameObject(typeof(T).Name);
        T generic = gameObject.AddComponent<T>();
        gameObject.transform.parent = parent;

        generic.Init();
        return generic;
    }


}

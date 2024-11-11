using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.Build.Content;
using UnityEngine;

public sealed class Managers : MonoBehaviour
{
    //Managers �ν��Ͻ�
    private static Managers instance;

    //������ Manager�� ���ϰ�
    public static UIManager UIManager { get { return instance.uiManager; } }
    public static GameManager GameManager { get { return instance.gameManager; } }


    //������ Manager�� �ν��Ͻ�
    private UIManager uiManager;
    private GameManager gameManager;



    //�����ֱ⿡�� awake���� �켱 ����
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //Managers�ʱ�ȭ �Լ�
    private static void Init()
    {
        Screen.SetResolution(760, 1280, false);

        GameObject gameObject = new GameObject("Managers");
        instance = gameObject.AddComponent<Managers>();
        DontDestroyOnLoad(gameObject);

        instance.uiManager = CreateManager<UIManager>(gameObject.transform);
    }




    //Manager�� hierarchy�� �������ִ� �Լ�
    private static T CreateManager<T>(Transform parent) where T : Component, IManager
    {
        GameObject gameObject = new GameObject(typeof(T).Name);
        T generic = gameObject.AddComponent<T>();
        gameObject.transform.parent = parent;

        generic.Init();
        return generic;
    }


}

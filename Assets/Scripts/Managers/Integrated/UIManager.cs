using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour,IManager
{
    //Readonly : 먼저 값을 넣으면 이후 수정 불가
    //Key값에 해당 하는 Enum을 넣으면 value값으로 GameObject 반환
    private readonly Dictionary <Enum, GameObject> UIStorge = new Dictionary<Enum, GameObject>();
    //UI를 열게되면 Stack에 추가 후입선출
    private readonly Stack<BasePopup> PopupStorge = new Stack<BasePopup>();

    public void Init()
    {
        //hiearchy에 추가할 popup의 경로
        CreatePopup<SceneType>("Prefabs/UI/SwitchScene");
        CreatePopup<UIType>("Prefabs/UI/Popup");
    }

    /// <summary>
    /// container에 값 넣어주는 함수
    /// </summary>
    private void CreatePopup<T>(string TypePath) where T : Enum
    {
        //팝업 불러오는 함수
        foreach(T type in Enum.GetValues(typeof(T)))
        {
            GameObject gameObject = Resources.Load<GameObject>(TypePath);

            if (gameObject == null)
                continue;
            //UIStorge Dictionary에 key값에 Type, value값에 불러올 Popup추가
            UIStorge.Add(type, gameObject);
        }
    }

    /// <summary>
    /// 씬에 기본 UI깔아주는 함수
    /// </summary>
    
}

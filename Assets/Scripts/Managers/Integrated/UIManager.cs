using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneLoadManager.OnLoadCompleted(SetBaseUI);
    }



    /// <summary>
    /// container에 값 넣어주는 함수
    /// </summary>
    private void CreatePopup<T>(string TypePath) where T : Enum
    {
        //팝업 불러오는 함수
        foreach(T type in Enum.GetValues(typeof(T)))
        {
            GameObject gameObject = Resources.Load<GameObject>(string.Format($"{TypePath}/{type.ToString()}"));

            if (gameObject == null)
                continue;
            //UIStorge Dictionary에 key값에 Type, value값에 불러올 Popup추가
            UIStorge.Add(type, gameObject);
        }
    }



    /// <summary>
    /// 씬에 기본 UI깔아주는 함수
    /// </summary>
    public void SetBaseUI(Scene scene, LoadSceneMode mode)
    {
        PopupStorge.Clear();

        SceneType type = StringToEnum.FormatStringToEnum<SceneType>(scene.name);
        CreateUI(type);
    }




    public BasePopup CreateUI(Enum type, bool curPopupActive = true)
    {
        if(!UIStorge.TryGetValue(type, out GameObject prefab))
        {
            Debug.LogWarning($"This is not Scene Base UI : {type}");
            return null;
        }

        GameObject clone = Instantiate(prefab);

        if(PopupStorge.TryPeek(out BasePopup beforeUI) && curPopupActive)
        {
            beforeUI.gameObject.SetActive(false);
        }

        BasePopup afterUI = clone.GetComponent<BasePopup>();
        afterUI.Init();

        PopupStorge.Push(afterUI);

        return afterUI;
    }




    public void CloseUI(Action LoadScene = null)
    {
        if(LoadScene != null)
        {
            PopupStorge.Clear();
            LoadScene();
            return;
        }

        if(PopupStorge.Count == 1)
        {
            return;
        }

        Destroy(PopupStorge.Pop().gameObject);

        if(PopupStorge.TryPeek(out BasePopup baseUI))
        {
            baseUI.gameObject.SetActive(true);
        }
    }
}

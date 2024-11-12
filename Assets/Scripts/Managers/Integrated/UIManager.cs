using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour,IManager
{
    //Readonly : ���� ���� ������ ���� ���� �Ұ�
    //Key���� �ش� �ϴ� Enum�� ������ value������ GameObject ��ȯ
    private readonly Dictionary <Enum, GameObject> UIStorge = new Dictionary<Enum, GameObject>();
    //UI�� ���ԵǸ� Stack�� �߰� ���Լ���
    private readonly Stack<BasePopup> PopupStorge = new Stack<BasePopup>();

    public void Init()
    {
        //hiearchy�� �߰��� popup�� ���
        CreatePopup<SceneType>("Prefabs/UI/SwitchScene");
        CreatePopup<UIType>("Prefabs/UI/Popup");
        SceneLoadManager.OnLoadCompleted(SetBaseUI);
    }



    /// <summary>
    /// container�� �� �־��ִ� �Լ�
    /// </summary>
    private void CreatePopup<T>(string TypePath) where T : Enum
    {
        //�˾� �ҷ����� �Լ�
        foreach(T type in Enum.GetValues(typeof(T)))
        {
            GameObject gameObject = Resources.Load<GameObject>(string.Format($"{TypePath}/{type.ToString()}"));

            if (gameObject == null)
                continue;
            //UIStorge Dictionary�� key���� Type, value���� �ҷ��� Popup�߰�
            UIStorge.Add(type, gameObject);
        }
    }



    /// <summary>
    /// ���� �⺻ UI����ִ� �Լ�
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

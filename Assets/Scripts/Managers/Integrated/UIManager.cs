using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    /// <summary>
    /// container�� �� �־��ִ� �Լ�
    /// </summary>
    private void CreatePopup<T>(string TypePath) where T : Enum
    {
        //�˾� �ҷ����� �Լ�
        foreach(T type in Enum.GetValues(typeof(T)))
        {
            GameObject gameObject = Resources.Load<GameObject>(TypePath);

            if (gameObject == null)
                continue;
            //UIStorge Dictionary�� key���� Type, value���� �ҷ��� Popup�߰�
            UIStorge.Add(type, gameObject);
        }
    }

    /// <summary>
    /// ���� �⺻ UI����ִ� �Լ�
    /// </summary>
    
}

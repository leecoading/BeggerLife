using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class GameManager : MonoBehaviour,IManager
{
    public float currentMoney = 0; //���� ������ ��

    public float clickPerMoney = 1; //Ŭ�� �� �����ϰ� �� �� ����
    public float moneyPerSec = 1; // �ʴ� �����ϰ� �� �� ����

    public float clickUpgradeCost = 100; //Ŭ�� �� ������ �� ��ȭ �ʱ� ���
    public float secUpgradeCost = 100; //�ʴ� ������ �� ��ȭ �ʱ� ���

    public int clickUpgradeLevel = 1; //���� Ŭ�� �� ������ �� ��ȭ ����(Ƚ��)
    public int secUpgradeLevel = 1; //���� �ʴ� ������ �� ��ȭ ����(Ƚ��)

    public int upgradeIncresement = 10; //��ȭ �� ������ �ʴ�/Ŭ���� ������ �� ����
    private const float costIncreseRate = 1.0f; //�ʴ� ������ �� ���ð�




    private void Awake()
    {
        StartCoroutine(AddMoneyPerSecondCoroutine());// 1�ʸ��� �� ���� �ڷ�ƾ ����
    }



    void Update()
    {
        // PC�� ���콺 Ŭ�� �Ǵ� �ȵ���̵��� ȭ�� ��ġ �Է� ����

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AddClickMoney(clickPerMoney);
        }
    }

  


    // 1�ʸ��� �ڵ����� ���� �߰��ϴ� �ڷ�ƾ
    private IEnumerator AddMoneyPerSecondCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1�� ���
            AddSecondMoney(moneyPerSec);
        }
    }

    //1�ʸ��� ���� ���� 1���� �����ִ� �Լ�
    public void AddSecondMoney(float amount)
    {
        currentMoney += amount;

    }
    void AddClickMoney(float amount)
    {
        currentMoney += amount;
        Managers.SoundManager.PlaySFX(SFXType.ScreenSound);
        Managers.UIManager.CreateUI(UIType.CoinPopup, false, false);
    }


    public void Init()
    {
        
    }
}



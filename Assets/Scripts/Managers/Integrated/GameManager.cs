using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour,IManager
{
    public float currentMoney = 0; //���� ������ ��

    public float clickPerMoney = 1; //Ŭ�� �� �����ϰ� �� �� ����
    public float moneyPerSec = 1; // �ʴ� �����ϰ� �� �� ����

    public float clickUpgradeCost = 100; //Ŭ�� �� ������ �� ��ȭ �ʱ� ���
    public float secUpgradeCost = 100; //�ʴ� ������ �� ��ȭ �ʱ� ���

    public int clickUpgradeLevel = 0; //���� Ŭ�� �� ������ �� ��ȭ ����(Ƚ��)
    public int secUpgradeLevel = 0; //���� �ʴ� ������ �� ��ȭ ����(Ƚ��)

    public int upgradeIncresement = 10; //��ȭ �� ������ �ʴ�/Ŭ���� ������ �� ����
    private const float costIncreseRate = 1.0f; //�ʴ� ������ �� ���ð�


    private void Start()
    {
        
        StartCoroutine(AddMoneyPerSecondCoroutine());// 1�ʸ��� �� ���� �ڷ�ƾ ����
    }


    // 1�ʸ��� ���� �߰��ϴ� �ڷ�ƾ
    private IEnumerator AddMoneyPerSecondCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1�� ���
            AddMoney(moneyPerSec);
        }
    }

    //1�ʸ��� ���� ���� 1���� �����ִ� �Լ�
    public void AddMoney(float amount)
    {
        currentMoney += amount;

        
    }

    // �� ������ ���� UI�� ������Ʈ�ϴ� �޼���
    private void UpdateMoneyUI()
    {
        
    }

    public void Init()
    {
        
    }
}



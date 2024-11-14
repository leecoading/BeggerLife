using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro; // TextMeshPro�� ����Ϸ��� �� ���ӽ����̽��� �߰�

public class GameManager : MonoBehaviour, IManager
{
    public BigInteger currentMoney = new BigInteger(10000000000000000000); //���� ������ ��
    public BigInteger clickPerMoney = 10000000000000000; //Ŭ�� �� �����ϰ� �� �� ����
    public BigInteger moneyPerSec = 10000000000000000; // �ʴ� �����ϰ� �� �� ����

    public float clickUpgradeCost = 100; //Ŭ�� �� ������ �� ��ȭ �ʱ� ���
    public float secUpgradeCost = 100; //�ʴ� ������ �� ��ȭ �ʱ� ���

    public int clickUpgradeLevel = 1; //���� Ŭ�� �� ������ �� ��ȭ ����(Ƚ��)
    public int secUpgradeLevel = 1; //���� �ʴ� ������ �� ��ȭ ����(Ƚ��)

    public float upgradeIncresement = 10; //��ȭ �� ������ �ʴ�/Ŭ���� ������ �� ����


    private void Awake()
    {
        StartCoroutine(AddMoneyPerSecondCoroutine()); // 1�ʸ��� �� ���� �ڷ�ƾ ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AddClickMoney(clickPerMoney);
        }

    }

    // �ݾ��� '��', '��', '��', '��' ������ ��ȯ�ϴ� �Լ�
    public string FormatMoney(BigInteger money)
    {
        BigInteger �Ѿ� = BigInteger.Pow(10, 8);
        BigInteger ���� = BigInteger.Pow(10, 12);
        BigInteger �ϰ� = BigInteger.Pow(10, 16);
        BigInteger ���� = BigInteger.Pow(10, 20);

        if (money >= ����)
            return (money / ����).ToString("0.##") + " ��"; // 2�ڸ� �Ҽ������� ǥ��
        else if (money >= �ϰ�)
            return (money / �ϰ�).ToString("0.##") + " ��";
        else if (money >= ����)
            return (money / ����).ToString("0.##") + " ��";
        else if (money >= �Ѿ�)
            return (money / �Ѿ�).ToString("0.##") + " ��";
        else
            return money.ToString("0"); // �Ҽ��� ���� ǥ��
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

    // 1�ʸ��� ���� ���� 1���� �����ִ� �Լ�
    public void AddSecondMoney(BigInteger amount)
    {
        currentMoney += amount;
    }

    // Ŭ�� �� ���� �߰��ϴ� �Լ�
    void AddClickMoney(BigInteger amount)
    {
        currentMoney += amount;
        Managers.SoundManager.PlaySFX(SFXType.ScreenSound);
        Managers.UIManager.CreateUI(UIType.CoinPopup, false, false);
    }

    public void Init()
    {
        // �ʱ�ȭ �ڵ�
    }
}



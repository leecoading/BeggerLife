using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro; // TextMeshPro를 사용하려면 이 네임스페이스를 추가

public class GameManager : MonoBehaviour, IManager
{
    public BigInteger currentMoney = new BigInteger(10000000000000000000); //현재 보유한 돈
    public BigInteger clickPerMoney = 10000000000000000; //클릭 당 증가하게 할 돈 비율
    public BigInteger moneyPerSec = 10000000000000000; // 초당 증가하게 할 돈 비율

    public float clickUpgradeCost = 100; //클릭 당 증가할 돈 강화 초기 비용
    public float secUpgradeCost = 100; //초당 증가할 돈 강화 초기 비용

    public int clickUpgradeLevel = 1; //현재 클릭 당 증가할 돈 강화 레벨(횟수)
    public int secUpgradeLevel = 1; //현재 초당 증가할 돈 강화 레벨(횟수)

    public float upgradeIncresement = 10; //강화 당 증가할 초당/클릭당 증가할 돈 비율


    private void Awake()
    {
        StartCoroutine(AddMoneyPerSecondCoroutine()); // 1초마다 돈 증가 코루틴 시작
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AddClickMoney(clickPerMoney);
        }

    }

    // 금액을 '억', '조', '경', '해' 단위로 변환하는 함수
    public string FormatMoney(BigInteger money)
    {
        BigInteger 한억 = BigInteger.Pow(10, 8);
        BigInteger 일조 = BigInteger.Pow(10, 12);
        BigInteger 일경 = BigInteger.Pow(10, 16);
        BigInteger 일해 = BigInteger.Pow(10, 20);

        if (money >= 일해)
            return (money / 일해).ToString("0.##") + " 해"; // 2자리 소수점까지 표시
        else if (money >= 일경)
            return (money / 일경).ToString("0.##") + " 경";
        else if (money >= 일조)
            return (money / 일조).ToString("0.##") + " 조";
        else if (money >= 한억)
            return (money / 한억).ToString("0.##") + " 억";
        else
            return money.ToString("0"); // 소수점 없이 표시
    }

    // 1초마다 자동으로 돈을 추가하는 코루틴
    private IEnumerator AddMoneyPerSecondCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1초 대기
            AddSecondMoney(moneyPerSec);
        }
    }

    // 1초마다 현재 돈에 1원씩 더해주는 함수
    public void AddSecondMoney(BigInteger amount)
    {
        currentMoney += amount;
    }

    // 클릭 시 돈을 추가하는 함수
    void AddClickMoney(BigInteger amount)
    {
        currentMoney += amount;
        Managers.SoundManager.PlaySFX(SFXType.ScreenSound);
        Managers.UIManager.CreateUI(UIType.CoinPopup, false, false);
    }

    public void Init()
    {
        // 초기화 코드
    }
}



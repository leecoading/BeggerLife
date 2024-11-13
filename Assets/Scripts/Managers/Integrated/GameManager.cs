using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour,IManager
{
    public float currentMoney = 0; //현재 보유한 돈

    public float clickPerMoney = 1; //클릭 당 증가하게 할 돈 비율
    public float moneyPerSec = 1; // 초당 증가하게 할 돈 비율

    public float clickUpgradeCost = 100; //클릭 당 증가할 돈 강화 초기 비용
    public float secUpgradeCost = 100; //초당 증가할 돈 강화 초기 비용

    public int clickUpgradeLevel = 0; //현재 클릭 당 증가할 돈 강화 레벨(횟수)
    public int secUpgradeLevel = 0; //현재 초당 증가할 돈 강화 레벨(횟수)

    public int upgradeIncresement = 10; //강화 당 증가할 초당/클릭당 증가할 돈 비율
    private const float costIncreseRate = 1.0f; //초당 증가할 돈 대기시간


    private void Start()
    {
        
        StartCoroutine(AddMoneyPerSecondCoroutine());// 1초마다 돈 증가 코루틴 시작
    }


    // 1초마다 돈을 추가하는 코루틴
    private IEnumerator AddMoneyPerSecondCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1초 대기
            AddMoney(moneyPerSec);
        }
    }

    //1초마다 현재 돈에 1원씩 더해주는 함수
    public void AddMoney(float amount)
    {
        currentMoney += amount;

        
    }

    // 현 상태의 돈을 UI에 업데이트하는 메서드
    private void UpdateMoneyUI()
    {
        
    }

    public void Init()
    {
        
    }
}



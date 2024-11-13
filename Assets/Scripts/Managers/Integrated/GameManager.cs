using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class GameManager : MonoBehaviour,IManager
{
    public float currentMoney = 0; //현재 보유한 돈

    public float clickPerMoney = 1; //클릭 당 증가하게 할 돈 비율
    public float moneyPerSec = 1; // 초당 증가하게 할 돈 비율

    public float clickUpgradeCost = 100; //클릭 당 증가할 돈 강화 초기 비용
    public float secUpgradeCost = 100; //초당 증가할 돈 강화 초기 비용

    public int clickUpgradeLevel = 1; //현재 클릭 당 증가할 돈 강화 레벨(횟수)
    public int secUpgradeLevel = 1; //현재 초당 증가할 돈 강화 레벨(횟수)

    public int upgradeIncresement = 10; //강화 당 증가할 초당/클릭당 증가할 돈 비율
    private const float costIncreseRate = 1.0f; //초당 증가할 돈 대기시간




    private void Awake()
    {
        StartCoroutine(AddMoneyPerSecondCoroutine());// 1초마다 돈 증가 코루틴 시작
    }



    void Update()
    {
        // PC의 마우스 클릭 또는 안드로이드의 화면 터치 입력 감지

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AddClickMoney(clickPerMoney);
        }
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

    //1초마다 현재 돈에 1원씩 더해주는 함수
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



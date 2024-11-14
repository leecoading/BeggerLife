using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Numerics;

public class AssetsPopup : BasePopup
{
    public TextMeshProUGUI seoulText;
    public TextMeshProUGUI earthText;
    public TextMeshProUGUI solarSystemText;

    public float seoulEarned;
    public float earthEarned;
    public float solarSystemEarned;

    BigInteger multiplier = new BigInteger(10);  // 0.1 * 100으로 처리
    public BuyPopup buyPopup;
    public void Start()
    {
        StartCoroutine(UpdateTextValues());
        buyPopup = FindAnyObjectByType<BuyPopup>();
        

    }

    private IEnumerator UpdateTextValues()
    {
        while (true)
        {
            // 각 텍스트에 1초마다 currentMoney의 0.1배, 0.2배, 0.3배를 더해줌
            seoulText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.1f)));
            earthText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.2f)));
            solarSystemText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.3f)));

            // 1초 대기
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnClickNextBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.AssetsPopup2, false);
    }

    public void OnClickSeoulBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        
            int valueToAdd = int.Parse(seoulText.text); // 문자열을 정수로 변환
            Managers.GameManager.currentMoney += valueToAdd;
        
    }

    public void OnClickEarthBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        int valueToAdd = int.Parse(earthText.text); // 문자열을 정수로 변환

        if(buyPopup.earthSoldout.activeSelf)
        {
            Managers.GameManager.currentMoney += valueToAdd;
            Managers.UIManager.CreateUI(UIType.CollectSucessPopup, false);
        }
        
        else
        {
            Managers.UIManager.CreateUI(UIType.CollectFaildPopup, false);
        }

    }

    public void OnClickSolarSystemBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        int valueToAdd = int.Parse(earthText.text); // 문자열을 정수로 변환

        if (buyPopup.solarSystemSoldout.activeSelf)
        {
            Managers.GameManager.currentMoney += valueToAdd;
            Managers.UIManager.CreateUI(UIType.CollectSucessPopup, false);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.CollectFaildPopup, false);
        }

    }


}

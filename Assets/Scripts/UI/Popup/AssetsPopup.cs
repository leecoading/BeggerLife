using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssetsPopup : BasePopup
{
    public TextMeshProUGUI seoulText;
    public TextMeshProUGUI earthText;
    public TextMeshProUGUI solarSystemText;

    public float seoulEarned;
    public float earthEarned;
    public float solarSystemEarned;

    public BuyPopup buyPopup;
    public void Start()
    {
        buyPopup = FindAnyObjectByType<BuyPopup>();
    }

    public void Update()
    {
        //seoulText.text = (Managers.GameManager.moneyPerSec * 0.1f).ToString("F0");
        //earthText.text = (Managers.GameManager.moneyPerSec * 0.2f).ToString("F0");
        //solarSystemText.text = (Managers.GameManager.moneyPerSec * 0.3f).ToString("F0");
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

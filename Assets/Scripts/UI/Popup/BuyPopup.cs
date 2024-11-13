using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPopup : BasePopup
{
    public GameObject earthSoldout;
    public GameObject solarSystemSoldout;
    public GameObject galaxySoldout;
    public GameObject spaceSoldout;
    public GameObject multiVerseSoldout;
    public void OnClickEarthBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 5000000000 && !earthSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec += 10000000);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney += 10000000);
            Managers.GameManager.currentMoney -= 5000000000;

            earthSoldout.SetActive(true);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickSolarSystemBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 1000000000000 && !earthSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec += 1000000000);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney += 1000000000);
            Managers.GameManager.currentMoney -= 1000000000000;

            earthSoldout.SetActive(true);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickGalaxyBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 250000000000000 && !earthSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec += 100000000000);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney += 100000000000);
            Managers.GameManager.currentMoney -= 250000000000000;

            earthSoldout.SetActive(true);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickSpaceBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 100000000000000000 && !earthSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec += 5000000000000);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney += 5000000000000);
            Managers.GameManager.currentMoney -= 100000000000000000;

            earthSoldout.SetActive(true);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickMultiVerseBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 9000000000000000000 && !earthSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec += 90000000000000);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney += 90000000000000);
            Managers.GameManager.currentMoney -= 9000000000000000000;

            earthSoldout.SetActive(true);
            Managers.UIManager.CreateUI(UIType.ClearPopup, false);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }
}
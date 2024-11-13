using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HirePopup : BasePopup
{
    public MenuPopup menuPopup;

    public GameObject begger2Soldout;
    public GameObject begger3Soldout;
    public GameObject begger4Soldout;
    public GameObject begger5Soldout;
    public GameObject begger6Soldout;

    public void Start()
    {
        menuPopup = FindObjectOfType<MenuPopup>();
    }

    public void OnClickBegger2()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 1000000000 && !begger2Soldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec * 1.3f);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney * 1.3f);
            Managers.GameManager.currentMoney -= 1000000000;

            begger2Soldout.SetActive(true);
            menuPopup.Begger2.SetActive(true);
            
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickBegger3()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 100000000000 && !begger3Soldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec * 1.4f);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney * 1.4f);
            Managers.GameManager.currentMoney -= 100000000000;

            begger3Soldout.SetActive(true);
            menuPopup.Begger3.SetActive(true);
            
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickBegger4()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 25000000000000 && !begger4Soldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec * 1.5f);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney * 1.5f);
            Managers.GameManager.currentMoney -= 25000000000000;

            begger4Soldout.SetActive(true);
            menuPopup.Begger4.SetActive(true);
            
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickBegger5()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 10000000000000000 && !begger5Soldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec * 1.7f);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney * 1.7f);
            Managers.GameManager.currentMoney -= 10000000000000000;

            begger5Soldout.SetActive(true);
            menuPopup.Begger5.SetActive(true);
            
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickBegger6()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 10000000000000000000 && !begger6Soldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec = Mathf.RoundToInt(Managers.GameManager.moneyPerSec * 2f);
            Managers.GameManager.clickPerMoney = Mathf.RoundToInt(Managers.GameManager.clickPerMoney * 2f);
            Managers.GameManager.currentMoney -= 10000000000000000000;

            begger6Soldout.SetActive(true);
            menuPopup.Begger6.SetActive(true);
            
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class BuyPopup : BasePopup
{
    public GameObject earthSoldout;
    public GameObject solarSystemSoldout;
    public GameObject galaxySoldout;
    public GameObject spaceSoldout;
    public GameObject multiVerseSoldout;

    public MenuPopup menuPopup;
    public AssetsPopup AssetsPopup;
    public AssetsPopup2 AssetsPopup2;

    public void Start()
    {
        menuPopup = FindAnyObjectByType<MenuPopup>();
        AssetsPopup = FindObjectOfType<AssetsPopup>();
        AssetsPopup2 = FindObjectOfType<AssetsPopup2>();
    }

    public void OnClickEarthBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 5000000000 && !earthSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec += new BigInteger(10000000); // 초당 증가할 돈 증가
            Managers.GameManager.clickPerMoney += new BigInteger(10000000); // 클릭당 증가할 돈 증가
            Managers.GameManager.currentMoney -= 5000000000;

            earthSoldout.SetActive(true);
            SceneLoadManager.LoadScene(SceneType.EarthScene);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickSolarSystemBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 1000000000000 && !solarSystemSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec += new BigInteger(1000000000); // 초당 증가할 돈 증가
            Managers.GameManager.clickPerMoney += new BigInteger(1000000000); // 클릭당 증가할 돈 증가
            Managers.GameManager.currentMoney -= 1000000000000;

            solarSystemSoldout.SetActive(true);
            SceneLoadManager.LoadScene(SceneType.SolarSystemScene);

        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickGalaxyBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 250000000000000 && !galaxySoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec += new BigInteger(100000000000); // 초당 증가할 돈 증가
            Managers.GameManager.clickPerMoney += new BigInteger(100000000000); // 클릭당 증가할 돈 증가
            Managers.GameManager.currentMoney -= 250000000000000;

            galaxySoldout.SetActive(true);
            SceneLoadManager.LoadScene(SceneType.GalaxyScene);

        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickSpaceBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 100000000000000000 && !spaceSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec += new BigInteger(5000000000000); // 초당 증가할 돈 증가
            Managers.GameManager.clickPerMoney += new BigInteger(5000000000000); // 클릭당 증가할 돈 증가
            Managers.GameManager.currentMoney -= 100000000000000000;

            spaceSoldout.SetActive(true);
            SceneLoadManager.LoadScene(SceneType.SpaceScene);

        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickMultiVerseBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        if (Managers.GameManager.currentMoney >= 9000000000000000000 && !multiVerseSoldout.activeSelf)
        {
            Managers.GameManager.moneyPerSec += new BigInteger(90000000000000); // 초당 증가할 돈 증가
            Managers.GameManager.clickPerMoney += new BigInteger(90000000000000); // 클릭당 증가할 돈 증가
            Managers.GameManager.currentMoney -= 9000000000000000000;

            multiVerseSoldout.SetActive(true);
            SceneLoadManager.LoadScene(SceneType.MultiverseScene);
            Managers.UIManager.CreateUI(UIType.ClearPopup, false);
            
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }
}

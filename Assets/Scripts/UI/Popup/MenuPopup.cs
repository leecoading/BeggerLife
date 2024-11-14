using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopup : BasePopup
{
    public GameObject Begger2;
    public GameObject Begger3;
    public GameObject Begger4;
    public GameObject Begger5;
    public GameObject Begger6;

    public TextMeshProUGUI currentMoney;
    public TextMeshProUGUI clickPerMoney;
    public TextMeshProUGUI moneyPerSec;


    public override void Init()
    {
        base.Init();
    }

    public void Update()
    {
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        //currentMoney.text = $"{Managers.GameManager.currentMoney}";
        currentMoney.text = Managers.GameManager.FormatMoney(Managers.GameManager.currentMoney);

        clickPerMoney.text = $"{Managers.GameManager.clickPerMoney}";
        moneyPerSec.text = $"{Managers.GameManager.moneyPerSec}";
    }

    




    public void OnClickBeggerUpgradeBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.UpgradePopup, false);
    }

    public void OnClickBeggerHireBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.HirePopup, false);
    }

    public void OnClickGambleBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.GamblePopup, true);
    }

    public void OnClickAssetsBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.AssetsPopup1, false);
    }

    public void OnClickBuyBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.BuyPopup, false);
    }

    public void OnClickSaveBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.SavePopup, false);
    }

    public void OnClickSettingBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.SettingPopup, false);
    }
}

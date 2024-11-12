using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuPopup : BasePopup
{
    // Money UI의 TextMeshProUGUI를 GameManager에서 업데이트할 수 있도록 공개
    public TextMeshProUGUI moneyText;
    public override void Init()
    {
        base.Init();
    }

    public void Start()
    {
        UpdatecurrentMoney();
    }

    private void UpdatecurrentMoney()
    {
        moneyText.text = $"{Managers.GameManager.currentMoney}";
    }

    public void OnClick()
    {
        Managers.GameManager.AddMoney(Managers.GameManager.clickPerMoney);
        UpdatecurrentMoney();
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

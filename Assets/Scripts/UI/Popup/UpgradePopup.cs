using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradePopup : BasePopup
{
    int secCurrentLevel = 0;
    int clickCurrentLevel = 0;

    public TextMeshProUGUI clickUpgradeCost;
    public TextMeshProUGUI secUpgradeCost;

    public TextMeshProUGUI clickPerMoney;
    public TextMeshProUGUI moneyPerSec;

    public TextMeshProUGUI clickUpgradeLevel;
    public TextMeshProUGUI secUpgradeLevel;

    
    public override void Init()
    {
        base.Init();
    }

    private void Update()
    {
        clickUpgradeCost.text = Managers.GameManager.clickUpgradeCost.ToString();
        secUpgradeCost.text = Managers.GameManager.secUpgradeCost.ToString();

        clickPerMoney.text = Managers.GameManager.clickPerMoney.ToString();
        moneyPerSec.text = Managers.GameManager.moneyPerSec.ToString();

        clickUpgradeLevel.text = Managers.GameManager.clickUpgradeLevel.ToString();
        secUpgradeLevel.text = Managers.GameManager.secUpgradeLevel.ToString();

    }

    public void OnClickSecUpgrade()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);

        if (Managers.GameManager.currentMoney >= Managers.GameManager.secUpgradeCost)
        {
            Managers.GameManager.moneyPerSec += Managers.GameManager.upgradeIncresement;
            Managers.GameManager.currentMoney -= Managers.GameManager.secUpgradeCost;

            Managers.GameManager.secUpgradeLevel++;

            Managers.GameManager.secUpgradeCost = Mathf.RoundToInt(Managers.GameManager.secUpgradeCost * 1.1f);

        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    public void OnClickClickUpgrade()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);

        if (Managers.GameManager.currentMoney >= Managers.GameManager.clickUpgradeCost)
        {
            Managers.GameManager.clickPerMoney += Managers.GameManager.upgradeIncresement;
            Managers.GameManager.currentMoney -= Managers.GameManager.clickUpgradeCost;

            Managers.GameManager.clickUpgradeLevel++;


            Managers.GameManager.clickUpgradeCost = Mathf.RoundToInt(Managers.GameManager.secUpgradeCost * 1.1f);
        }

        else
        {
            Managers.UIManager.CreateUI(UIType.BuyFaildPopup, false);
        }
    }

    
}

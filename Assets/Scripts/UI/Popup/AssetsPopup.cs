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

    BigInteger multiplier = new BigInteger(10);  // 0.1 * 100���� ó��
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
            // �� �ؽ�Ʈ�� 1�ʸ��� currentMoney�� 0.1��, 0.2��, 0.3�踦 ������
            seoulText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.1f)));
            earthText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.2f)));
            solarSystemText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.3f)));

            // 1�� ���
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
        
            int valueToAdd = int.Parse(seoulText.text); // ���ڿ��� ������ ��ȯ
            Managers.GameManager.currentMoney += valueToAdd;
        
    }

    public void OnClickEarthBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        int valueToAdd = int.Parse(earthText.text); // ���ڿ��� ������ ��ȯ

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
        int valueToAdd = int.Parse(earthText.text); // ���ڿ��� ������ ��ȯ

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

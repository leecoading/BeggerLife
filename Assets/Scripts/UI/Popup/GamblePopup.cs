using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GamblePopup : BasePopup
{

    public void OnClick50Button()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        float randomValue = Random.Range(0f, 1f);

        // 50% È®·ü·Î ´çÃ·
        if (randomValue < 0.5f)
        {
            // currentMoney¿¡ 1.5¹è¸¦ °öÇÑ °ªÀ» BigInteger·Î º¯È¯
            Managers.GameManager.currentMoney = BigInteger.Multiply(Managers.GameManager.currentMoney, new BigInteger(1.5f));
            Managers.UIManager.CreateUI(UIType.TrySucessedPopup);
        }
        else
        {
            Managers.GameManager.currentMoney = BigInteger.Zero;
            Managers.UIManager.CreateUI(UIType.TryFaildPopup);
        }
    }

    public void OnClick30Button()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        float randomValue = Random.Range(0f, 1f);

        // 30% È®·ü·Î ´çÃ·
        if (randomValue < 0.3f)
        {
            // currentMoney¿¡ 2.5¹è¸¦ °öÇÑ °ªÀ» BigInteger·Î º¯È¯
            Managers.GameManager.currentMoney = BigInteger.Multiply(Managers.GameManager.currentMoney, new BigInteger(2.5f));
            Managers.UIManager.CreateUI(UIType.TrySucessedPopup);
        }
        else
        {
            Managers.GameManager.currentMoney = BigInteger.Zero;
            Managers.UIManager.CreateUI(UIType.TryFaildPopup);
        }
    }

    public void OnClick10Button()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        float randomValue = Random.Range(0f, 1f);

        // 10% È®·ü·Î ´çÃ·
        if (randomValue < 0.11f)
        {
            Managers.GameManager.currentMoney = BigInteger.Multiply(Managers.GameManager.currentMoney, new BigInteger(7.7f));
            Managers.UIManager.CreateUI(UIType.TrySucessedPopup);
        }
        else
        {
            Managers.GameManager.currentMoney = BigInteger.Zero;
            Managers.UIManager.CreateUI(UIType.TryFaildPopup);
        }

    }
}




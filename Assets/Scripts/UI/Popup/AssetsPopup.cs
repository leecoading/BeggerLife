using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsPopup : BasePopup
{
    public void OnClickNextBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
        Managers.UIManager.CreateUI(UIType.AssetsPopup2, false);
    }

}

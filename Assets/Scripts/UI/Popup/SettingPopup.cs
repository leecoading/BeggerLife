using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : BasePopup
{
    public void OnClickExitBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 플레이 모드 중지
#else
            Application.Quit(); // 빌드된 게임 종료
#endif
    }
}

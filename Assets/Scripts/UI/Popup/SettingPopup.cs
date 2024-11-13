using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : BasePopup
{
    public void OnClickExitBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.ButtonSound);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ��� �÷��� ��� ����
#else
            Application.Quit(); // ����� ���� ����
#endif
    }
}

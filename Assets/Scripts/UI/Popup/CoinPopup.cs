using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPopup : BasePopup
{
    public TextMeshProUGUI clickPerMoney;

    private void Start()
    {
        
        StartCoroutine(DestroyAfterDelay(0.5f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        clickPerMoney.text = Managers.GameManager.FormatMoney(Managers.GameManager.clickPerMoney);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

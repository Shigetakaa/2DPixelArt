using UnityEngine;

public class ResetUpgradesButton : MonoBehaviour
{
    public void OnResetUpgradesButton()
    {
        UpgradesManager.Instance.ResetUpgrades();
    }
}

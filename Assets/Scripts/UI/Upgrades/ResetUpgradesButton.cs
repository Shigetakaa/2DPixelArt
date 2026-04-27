using UnityEngine;

public class ResetUpgradesButton : MonoBehaviour
{
    public AudioClip resetSound;

    public void OnResetUpgradesButton()
    {
        SoundManager.instance.PlaySound(resetSound, transform, 1f);

        UpgradesManager.Instance.ResetUpgrades();
    }
}

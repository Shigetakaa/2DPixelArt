using UnityEngine;

public class ResetUpgradesButton : MonoBehaviour
{
    public AudioClip resetSound;

    public void OnResetUpgradesButton()
    {
        UpgradesManager.Instance.ResetUpgrades();

        // SoundManager.instance.PlaySound(resetSound, transform, 1f);
    }
}

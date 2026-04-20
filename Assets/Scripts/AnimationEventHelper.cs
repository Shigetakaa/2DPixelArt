using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHelper : MonoBehaviour
{
    public UnityEvent OnAttackPerformed;
    public UnityEvent OnThunderTriggered;

    public UnityEvent OnBossAoeTriggered;

    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }

    public void TriggerThunder()
    {
        OnThunderTriggered?.Invoke();
    }

    public void TriggerBossAoe()
    {
        OnBossAoeTriggered?.Invoke();
    }
}

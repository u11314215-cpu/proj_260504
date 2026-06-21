using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour // 這裡改名
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(string triggerName)
    {
        if (anim != null) anim.SetTrigger(triggerName);
    }

    public void SetBool(string boolName, bool value)
    {
        if (anim != null) anim.SetBool(boolName, value);
    }
}
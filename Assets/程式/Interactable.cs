using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnFocus()
    {
        Debug.Log(name + " 被看著");
    }

    public virtual void OnLoseFocus()
    {
        Debug.Log(name + " 失去焦點");
    }

    public virtual void Interact()
    {
        Debug.Log(name + " 被互動");
    }
}
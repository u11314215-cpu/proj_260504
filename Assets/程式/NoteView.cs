using UnityEngine;
using UnityEngine.UI;

public class NoteView : MonoBehaviour
{
    public GameObject panel;
    public Sprite image;

    public void OpenNote()
    {
        panel.SetActive(true);
        panel.GetComponent<Image>().sprite = image;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text promptText;

    void Awake()
    {
        // 單例（避免你之後多個UIManager出錯）
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        HidePrompt();
    }

    public void ShowPrompt(string message)
    {
        if (promptText == null) return;

        promptText.gameObject.SetActive(true);
        promptText.text = message;
    }

    public void HidePrompt()
    {
        if (promptText == null) return;

        promptText.gameObject.SetActive(false);
    }
}
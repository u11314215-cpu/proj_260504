using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI")]
    public GameObject startPanel;
    public GameObject dialoguePanel;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    [Header("Cutscene")]
    public IntroCutscene introCutscene;

    [Header("Dialogue Data")]
    public DialogueLine[] lines;

    public RitualTimer ritualTimer;

    private int index = 0;
    public bool isTalking = false;
    private bool gameStarted = false;

    private float inputCooldown = 0f;

    void Start()
    {
        Debug.Log("DialogueSystem Start OK");

        if (startPanel != null)
            startPanel.SetActive(true);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Time.time < inputCooldown) return;

        // 🎬 開始遊戲（空白鍵）
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;

            if (startPanel != null)
                startPanel.SetActive(false);

            inputCooldown = Time.time + 0.3f;

            // 只開對話，不開 cutscene
            StartDialogue();
        }

        // 💬 對話下一句
        if (gameStarted && isTalking && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
            inputCooldown = Time.time + 0.2f;
        }
    }

    public void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("No dialogue lines!");
            return;
        }

        isTalking = true;
        index = 0;

        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ShowLine();
    }

    void ShowLine()
    {
        if (index < 0 || index >= lines.Length) return;

        if (nameText != null)
            nameText.text = lines[index].speaker;

        if (dialogueText != null)
            dialogueText.text = lines[index].text;
    }

    void NextLine()
    {
        index++;

        if (index < lines.Length)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isTalking = false;

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        Debug.Log("Dialogue End");

        if (introCutscene == null)
        {
            Debug.LogError("❌ introCutscene 沒有綁！");
            return;
        }

        if (!introCutscene.isRunning)
        {
            Debug.Log("✅ 正在啟動 Cutscene");
            introCutscene.StartCutscene();
        }
        if (ritualTimer != null)
        {
            ritualTimer.StartTimer();
        }
    }
}
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RitualTimer : MonoBehaviour
{
    [Header("時間設定")]
    public float limitTime = 600f; // 10分鐘 (600秒)
    private float currentTime = 0f;

    [HideInInspector]
    public bool isRunning = false;

    [Header("UI 顯示")]
    public TextMeshProUGUI timeText;

    // 🌟 新增：把你的「遊戲失敗 UI 物件」拖到這裡
    [Header("結束與失敗設定")]
    public GameObject gameOverPanel;

    public void RestartGame()
    {
        // 重新載入當前的場景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("離開遊戲");
    }

    void Start()
    {
        if (timeText != null)
        {
            timeText.gameObject.SetActive(false);
        }
        if (timeText != null) timeText.gameObject.SetActive(false);
        // 🌟 遊戲一開始，先把失敗畫面藏起來
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        UpdateTimerUI();
    }

    public void StartTimer()
    {
        if (!isRunning)
        {
            isRunning = true;
            if (timeText != null)
            {
                timeText.gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (!isRunning) return;

        if (currentTime >= limitTime)
        {
            currentTime = limitTime;
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        UpdateTimerUI();

        // 🌟 當時間正式倒數完畢
        if (currentTime >= limitTime)
        {
            OnTimerComplete();
        }
    }

    void UpdateTimerUI()
    {
        float t = currentTime / limitTime;
        float startHour = 23f;
        float endHour = 9f;
        float totalHours = Mathf.Lerp(startHour, 24f + endHour, t);

        if (totalHours >= 24f)
            totalHours -= 24f;

        int displayHour = Mathf.FloorToInt(totalHours);
        float remainderMinutes = (totalHours - Mathf.Floor(totalHours)) * 60f;
        int displayMinute = Mathf.FloorToInt(remainderMinutes);

        if (timeText != null)
        {
            timeText.text = $"儀式時間：{displayHour:00}:{displayMinute:00}";
        }
    }

    // 🌟 時間到了！執行遊戲失敗
    void OnTimerComplete()
    {
        isRunning = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        // 鎖定狀態解除，讓玩家可以點選失敗畫面上的按鈕
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f; // 停止遊戲世界時間
    }
}
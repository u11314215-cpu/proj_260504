using UnityEngine;

public class LanternSystem : MonoBehaviour
{
    [Header("四顆燈籠")]
    public GameObject[] lanterns = new GameObject[4];

    private int currentIndex = 0;
    private bool[] taskCompleted = new bool[4];

    public GameObject winUI;

    void Start()
    {
        ResetLanterns();
    }

    // =========================
    // 👉 完成一個任務就呼叫這個
    // =========================
    public void CompleteTask(int taskIndex)
    {
        if (taskIndex < 0 || taskIndex >= 4) return;

        // ❗已經完成過就不重複亮
        if (taskCompleted[taskIndex]) return;

        taskCompleted[taskIndex] = true;

        // 點亮對應燈籠
        if (lanterns[taskIndex] != null)
            lanterns[taskIndex].SetActive(true);

        Debug.Log("🏮 任務完成：" + taskIndex);

        CheckWin();
    }

    // =========================
    // 👉 檢查是否全部完成
    // =========================
    void CheckWin()
    {
        for (int i = 0; i < taskCompleted.Length; i++)
        {
            if (!taskCompleted[i]) return;
        }

        Debug.Log("🎉 全部燈籠點亮！通關！");

        if (winUI != null)
            winUI.SetActive(true);
    }

    // =========================
    // 重置
    // =========================
    public void ResetLanterns()
    {
        for (int i = 0; i < lanterns.Length; i++)
        {
            if (lanterns[i] != null)
                lanterns[i].SetActive(false);
        }

        for (int i = 0; i < taskCompleted.Length; i++)
        {
            taskCompleted[i] = false;
        }

        if (winUI != null)
            winUI.SetActive(false);

        currentIndex = 0;
    }
}
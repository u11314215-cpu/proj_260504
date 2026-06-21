using UnityEngine;

public class RitualManager : MonoBehaviour
{
    public int completed;
    public int total = 4;
    public GameObject winPanel;

    public LanternLight[] lanterns;

    public void CompleteTask(int id)
    {
        completed++;

        if (lanterns != null && id < lanterns.Length)
            lanterns[id].LightUp();

        if (completed >= total)
            Win();
    }

    void Win()
    {
        Debug.Log("通關！");
        if (winPanel != null)
            winPanel.SetActive(true);
    }
}
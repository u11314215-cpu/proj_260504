using UnityEngine;

public class CandleController : MonoBehaviour
{
    public GameObject fire;
    public Light lightSource;
    public RitualManager ritualManager;

    public float targetIntensity = 2f;
    public int candleTaskID = 2;
    private static int count = 0;
    private bool isLit = false;

    void Start()
    {
        // 確保剛開始是滅的
        if (fire != null) fire.SetActive(false);
        if (lightSource != null) lightSource.intensity = 0;
    }

    // 這個方法將被 Interactable 呼叫
    public void Interact()
    {
        LightCandle();
    }

    public void LightCandle()
    {
        if (isLit) return;

        isLit = true;

        if (fire != null)
            fire.SetActive(true);

        if (lightSource != null)
            lightSource.intensity = targetIntensity;

        count++;
        Debug.Log("蠟燭點亮，目前數量: " + count);

        if (count >= 2 && ritualManager != null)
        {
            ritualManager.CompleteTask(candleTaskID);
        }
    }
}
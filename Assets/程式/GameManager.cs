using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera; // 直接拖進去
    public FPSController cameraController; // 拖進去

    public void StartGameMode()
    {
        // 過場結束後，啟用自由視角控制
        cameraController.enabled = true;
    }
}
using System.Collections;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    [Header("角色")]
    public Transform npcTransform;
    public Transform exitPoint;
    public GameObject taoistObject;
    public GameObject taoistMasterObject;

    [Header("控制")]
    public FPSController playerController;
    public DialogueSystem dialogueSystem;

    [Header("鏡頭")]
    public GameObject mainCamera;
    public GameObject introCamera;

    [Header("黑屏")]
    public GameObject blackPanel;

    public bool isRunning = false;

    void Start()
    {
        if (blackPanel != null)
            blackPanel.SetActive(false);
    }

    public void StartCutscene()
    {
        StartCoroutine(CutsceneRoutine());
    }

    public IEnumerator CutsceneRoutine()
    {
        Debug.Log("=== Cutscene 開始 ===");
        isRunning = true;

        // ... (前段程式碼保持不變：鎖定玩家、檢查物件) ...

        // ===== 轉身 =====
        Debug.Log("開始轉身");

        // 【修正點】：在外面宣告 targetRot，讓整個協程都看得到
        Quaternion targetRot = Quaternion.identity;

        Vector3 dir = exitPoint.position - npcTransform.position;
        dir.y = 0;

        if (dir.sqrMagnitude > 0.01f)
        {
            targetRot = Quaternion.LookRotation(dir); // 直接賦值給外面的變數

            float t = 0;
            while (t < 1f)
            {
                npcTransform.rotation = Quaternion.Slerp(npcTransform.rotation, targetRot, t);
                t += Time.deltaTime * 2f;
                yield return null;
            }
            npcTransform.rotation = targetRot;
        }
        Debug.Log("轉身完成");

        // ===== 開始走 =====
        AutoMove autoMove = npcTransform.GetComponent<AutoMove>();
        if (autoMove != null)
        {
            autoMove.StartAutoMove(exitPoint);

            float walkDuration = 1.5f;
            float timer = 0;

            while (timer < walkDuration)
            {
                timer += Time.deltaTime;
                // 【現在這裡就可以正常使用 targetRot 了】
                npcTransform.rotation = targetRot;

                if (autoMove.isMoving == false) break;
                yield return null;
            }

            autoMove.isMoving = false;
            Debug.Log("移動時間結束，強制黑屏");
        }

        // ... (後面黑屏與恢復玩家的代碼) ...


        /// ===== 黑屏 =====
        if (blackPanel != null)
        {
            Debug.Log("黑屏開啟");
            blackPanel.SetActive(true);
        }

        // ===== 隱藏徒弟與道士 =====
        if (taoistObject != null)
            taoistObject.SetActive(false); // 隱藏徒弟

        if (taoistMasterObject != null)
            taoistMasterObject.SetActive(false); // 隱藏道士
        else
            Debug.LogWarning("注意：道士物件 (taoistMasterObject) 沒有在 Inspector 綁定！");

        yield return new WaitForSeconds(1f);

        // ===== 切回玩家鏡頭 =====
        if (introCamera != null)
            introCamera.SetActive(false);

        if (mainCamera != null)
            mainCamera.SetActive(true);

        // ===== 恢復玩家 =====
        if (playerController != null)
            playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yield return new WaitForSeconds(0.5f);

        if (blackPanel != null)
            blackPanel.SetActive(false);

        isRunning = false;

        Debug.Log("=== Cutscene 結束 ===");
    }
}
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AutoMove : MonoBehaviour
{
    [Header("移動設定")]
    public float speed = 3.5f;
    public float stopDistance = 0.2f;

    [Header("狀態")]
    public bool isMoving = false;
    public Transform target;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isMoving || target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;

        if (distance <= stopDistance)
        {
            isMoving = false;
            return;
        }

        Vector3 moveDir = direction.normalized;

        // ✔ 只用 Move（唯一移動方式）
        controller.Move(moveDir * speed * Time.deltaTime);

        // ✔ 只轉 Y 軸（不影響上下）
        if (moveDir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rot,
                10f * Time.deltaTime
            );
        }
    }

    public void StartAutoMove(Transform newTarget)
    {
        target = newTarget;
        isMoving = true;
    }
}
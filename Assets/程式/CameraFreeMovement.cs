using UnityEngine;

public class CameraFreeMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 這樣攝影機就可以獨立移動，不依賴任何角色模型
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ));
    }
}
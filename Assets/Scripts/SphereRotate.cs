using UnityEngine;

public class RotateAroundZAxis : MonoBehaviour
{
    public float rotationSpeed = 50f; // 旋转速度（每秒度数）
    public bool rotateClockwise = true; // 是否顺时针旋转

    void Update()
    {
        // 确定旋转方向
        float direction = rotateClockwise ? -1 : 1;

        // 计算旋转角度
        float rotationAmount = direction * rotationSpeed * Time.deltaTime;

        // 按照 Z 轴旋转
        transform.Rotate(0, 0, rotationAmount);
    }
}
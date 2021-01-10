using UnityEngine;

public class CameraControl2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤物件"), Range(0, 100)]
    public float speed = 3.5f;


    /// <summary>
    /// 追蹤目標物件
    /// </summary>
    private void Track()
    {
        Vector3 posA = target.position;         //取得玩家座標
        Vector3 posB = transform.position;      //取得攝影機座標
        posA.z = -10;                           //攝影機Z軸維持-10

        //差值
        posB = Vector3.Lerp(posB, posA, 0.5f * speed * Time.deltaTime);
        transform.position = posB;
    }

    private void LateUpdate()
    {
        Track();
    }

}

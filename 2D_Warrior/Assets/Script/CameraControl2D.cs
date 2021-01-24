using UnityEngine;
using System.Collections; //協同程序需要 

public class CameraControl2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤物件"), Range(0, 100)]
    public float speed = 3.5f;
    [Header("晃動區間"), Range(0, 1)]
    public float shaketime = 0.05f;
    [Header("晃動值"), Range(0, 5)]
    public float shake = 0.5f;
    [Header("晃動次數"), Range(0, 5)]
    public int shakecount = 3;

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

    public IEnumerator Shake()
    {
        for (int i = 0; i < shakecount; i++)
        {
            transform.position += Vector3.up * shake;
            yield return new WaitForSeconds(shaketime);
            transform.position -= Vector3.up * shake;
            yield return new WaitForSeconds(shaketime);
        }        
        
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈攻擊力
    /// </summary>
    public float attack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰撞物件有 Boss 腳本
        if (collision.gameObject.GetComponent<Boss>())
        {
            //對 Boss 呼叫 Damage
            collision.gameObject.GetComponent<Boss>().Damage(attack);
        }
    }

}

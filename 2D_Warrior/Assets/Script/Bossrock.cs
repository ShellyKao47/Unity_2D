using UnityEngine;

public class Bossrock : MonoBehaviour
{
    [Header("攻擊力")]
    public float attack = 25;

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Hurt(attack);
        }
    }
}

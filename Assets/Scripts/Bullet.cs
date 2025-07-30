using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int per;

    public void Init(int damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }
}

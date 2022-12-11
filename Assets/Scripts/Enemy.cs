
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    //reducing enemy health by damage set from gun
    public void takeDamage(float amountDamage)
    {
        health -= amountDamage;

        if (health <= 0f)
        {
            enemyDie();
        }
    }

    //have the enemy "die"
    void enemyDie()
    {
        Destroy(gameObject);
    }
}

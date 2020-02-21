using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float movementSpeed;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D enemyRigidBoy, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(enemyRigidBoy, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D enemyRigidBody, float knockTime)
    {
        if (enemyRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemyRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            enemyRigidBody.velocity = Vector2.zero;
        }
    }
}

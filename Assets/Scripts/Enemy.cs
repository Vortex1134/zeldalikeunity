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
    public float health;
    public FloatValue maxHealth;
    public string enemyName;
    public float moveSpeed;
    public int baseAttack;
    public EnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }
}

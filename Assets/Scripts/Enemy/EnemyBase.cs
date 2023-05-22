using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAtack = "Attack";
    public string triggerKill = "Death";

    public HealthBase health;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if(health != null)
        {
            health.OnKill += onEnemyKill;
        }
    }

    public void onEnemyKill()
    {
        health.OnKill -= onEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();

        }
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAtack);
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerKill);
    }

    public void Damage(int amount)
    {
        health.Damage(amount);
    }
}

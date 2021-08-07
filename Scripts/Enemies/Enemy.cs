using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health = 100;
    public int Health  { get => _health; set => _health = value; }
    private Animator _animator;
    private void Start()
    {
  
        _animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            StartCoroutine(ExecuteAfterTime(2));

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            
            StartCoroutine(ExecuteAfterTime(1));
        }
    }

    public void Die()
    {
        
        Destroy(gameObject);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(time);
        Die();
    }
   
    
}

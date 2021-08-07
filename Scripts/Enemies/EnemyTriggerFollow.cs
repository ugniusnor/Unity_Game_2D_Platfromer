using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerFollow : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    private EnemyFollow enemyFollow;
    private bool isActive = false;
    private void Start()
    {
        enemyFollow = enemy.GetComponent<EnemyFollow>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 100)
        {
            
            isActive = true;
            enemyFollow.Trigger=isActive;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yes");
        isActive = true;
        enemyFollow.Trigger = isActive;
    }
  


    public bool getIsActive()
    {
        return isActive;
    }

}

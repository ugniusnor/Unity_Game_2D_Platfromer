using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Animator _animator;
    public Transform firePoint;
    public GameObject spellPrefab;[SerializeField] float destroyDelay = 2f;
    private int currentMana;
    private Player player;
    [SerializeField] private float spellDelayTime = 0.5f;
    private float lastSpellCast;
    // Update is called once per frame

    private void Start()
    {
        _animator = GetComponent<Animator>();
        player = GetComponent<Player>();
       
    }
    void Update()
    {
 
        currentMana = player.Mana;
        if (Input.GetButtonDown("Fire1") && (Time.time - lastSpellCast > spellDelayTime))
        {

            Shoot();
            lastSpellCast = Time.time;
        }
    }
    public void Shoot()
    {

        if(currentMana >= 25)
        {
            _animator.SetTrigger("magic");
            player.Mana =  currentMana - 23;
            Instantiate(spellPrefab, firePoint.position, firePoint.rotation);

        }

    }
}

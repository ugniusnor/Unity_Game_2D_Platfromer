using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;
    public int Health { get => _health; set => _health = value; }
    private int _mana = 100;
    public int Mana { get { return _mana; } set { _mana = value; } }
    [SerializeField] int manaToAdd = 7;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    [SerializeField] GameObject healthBar;
    private ScenesManager scenesManager;
    private int _coins;
    public int Coins { get => _coins; set => _coins = value; }

    private bool isDead = false;
    private void Start()
    {
        _coins = 0;
        scenesManager = GetComponent<ScenesManager>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(AddMana), 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            StartCoroutine(ExecuteAfterTime(1));


        }
        if (isDead)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water" || collision.tag == "Obstacle")
        {
            Health = 0;
            Die();
        }


    }
    public void TakeDamage(int damage)
    {
        if (Health <= 0) { return; }

        Health -= damage;
    }

    public void Die()
    {
        isDead = true;


    }



    void AddMana()
    {
        if (_mana < 100)
        {

            _mana += manaToAdd;
        }
        //else
        //    CancelInvoke(nameof(AddMana));
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(time);
        Die();
        scenesManager.GameOver();
    }
}

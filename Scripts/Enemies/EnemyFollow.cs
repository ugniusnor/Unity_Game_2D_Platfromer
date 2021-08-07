using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] GameObject target;
    [SerializeField] Enemy _enemny;
    [SerializeField] private int allowedDistance = 14;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private Transform TargetPossition;
    private bool isWalking;
    private float horizontal;
    private Player player;
    private bool isTriggered = false;
    public bool Trigger { get => isTriggered; set => isTriggered = value;}
    // Start is called before the first frame update
    void Start()
    {

        player = target.GetComponent<Player>();
        TargetPossition = target.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (target.transform.position.x < transform.position.x)
        {
           
            transform.localScale = new Vector2(5, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-5, transform.localScale.y);
        }

        if (!isTriggered) return;
        

        if (_enemny.Health <= 0)
        {
            _rigidBody.constraints = RigidbodyConstraints2D.None;
            return;
        }
        if (player.Health <= 0)
        {
            _animator.SetBool("Attack", false);
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            return;
        }
        if (Vector3.Distance(transform.position, TargetPossition.position) >= allowedDistance)
        {
            _animator.SetBool("Attack", false);
            isWalking = true;
            transform.position = Vector3.MoveTowards(transform.position, TargetPossition.position, speed * Time.deltaTime);

            _animator.SetBool("Walking", isWalking);
        }
        else
        {
            isWalking = false;
            _animator.SetBool("Walking", isWalking);
            _animator.SetBool("Attack", true);

        }


    }

}


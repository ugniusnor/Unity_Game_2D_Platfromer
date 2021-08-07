using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpFroce;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider2D;
    float horizontal;
    public bool isToTheLeft;
    bool isFirePointRotated = false;
    GameObject firepoint;
    private Player player;
    private void Start()
    {
        player = GetComponent<Player>();
      
        isToTheLeft = true;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        firepoint = GameObject.Find("/Character/FirePoint");
    }
    void Update()
    {
        if(player.Health <=0)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        bool isWalking = horizontal != 0;

        _animator.SetBool("walking", isWalking);
        transform.position += new Vector3(horizontal * Time.deltaTime * movementSpeed,0,0);
        int direction = horizontal > 0 ? -1 : 1;
        transform.localScale = new Vector2(direction * 5, transform.localScale.y);
        
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f &&  Input.GetKeyDown(KeyCode.Space))
        {
          
            
            _rigidbody.velocity = Vector3.up * jumpFroce;
            

        }
        RotateFirePoint();
        
        if (isToTheLeft)
           
        {
            transform.localScale = new Vector2(-5, transform.localScale.y);

           
        }
        if (horizontal > 0)
        {
            isToTheLeft = true;
        } else if(horizontal < 0)
        {
            isToTheLeft = false;
        }
        
        
       
    }
    
      public void RotateFirePoint()
    {
        if(isToTheLeft && !isFirePointRotated)
        {
        
            //firepoint.transform.Rotate(0f, 180f, 0f);
            firepoint.transform.rotation = Quaternion.Euler(0, 0, 0);
            isFirePointRotated = !isFirePointRotated; ;
        } else if(!isToTheLeft && isFirePointRotated)
        {

            //firepoint.transform.Rotate(0f, 180f, 0f);
            firepoint.transform.rotation = Quaternion.Euler(0, 180, 0);
            isFirePointRotated = !isFirePointRotated;
        }
       
    }
    public bool GetIsToTheLeft
    {
        get { return isToTheLeft; }
    }


    }
    


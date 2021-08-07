using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject VictoryScreen;
    // Start is called before the first frame update

    void Start()
    {
        VictoryScreen.SetActive(false);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            VictoryScreen.SetActive(true);
            Time.timeScale = 0;
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinsManager : MonoBehaviour
{
    [SerializeField] GameObject coinTextObj;
    [SerializeField] GameObject character;
    private Player player;
    private Text coinText;
    private int currentCoins;
    private string staticText = "Coins: ";
    bool isColliding = false;
    private void Start()
    {
        player = character.GetComponent<Player>();
        coinText = coinTextObj.GetComponent<Text>();
        currentCoins = player.Coins;
        coinText.text = staticText + currentCoins.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
      
        if (collision.gameObject.tag == "Player")
        {
            AddCoin();

        }
    }
   
    private void AddCoin()
    {
        Destroy(gameObject);
        player.Coins  += 1;

        ChangeCoinUi();

    }

    private void ChangeCoinUi()
    {
        coinText.text = staticText + player.Coins.ToString();

    }
}

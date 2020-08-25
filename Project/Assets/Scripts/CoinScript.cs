using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int coinValue;

    public int rotateSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
            
    }
}

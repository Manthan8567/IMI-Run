using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public Transform spawnpoint;
    public PlayerComponent player;
    public float TimeToRespawn = 2f;
    public float timer = 0;

    public static bool isGameOver;

    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = spawnpoint.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive == false)
        {
            if (timer < TimeToRespawn)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (lives > 0)
                {
                    lives--;
                    player.transform.position = spawnpoint.transform.position;
                    player.isAlive = true;
                    timer = 0;
                }
                if(lives<=0)
                {
                    
                    gameOverScreen.SetActive(true);
                    Debug.Log("GameOver");
                }
            }
        }
    }
    public void FinishLevel()
    {
        Debug.Log("Level Finish");
    }
        
    


    
}

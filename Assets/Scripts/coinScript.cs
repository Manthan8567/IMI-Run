using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            ScoreTextScript.coinAmount++;
            Debug.Log("coin picked!");
            Destroy(collision.gameObject);
        }
    }
}

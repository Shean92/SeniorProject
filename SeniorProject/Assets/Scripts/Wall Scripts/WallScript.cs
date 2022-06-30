using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager game;
    public int enemyCount;


    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (game.enemyKillCount >= enemyCount)
        {
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }

    }
}

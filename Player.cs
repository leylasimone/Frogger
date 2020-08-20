﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEditor.ShortcutManagement;
using UnityEngine;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = ""; //The players name for the purpose of storing the high score

    public GameObject scoreText;

    public const int playerTotalLives = 10; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.

    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?
    public GameObject bullet;

    private string myScore;
    private GameManager myGameManager; //A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        //myScore = "Score: ";
        //scoreText = GameObject.Find("ScoreText");
        myGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCanMove && playerIsAlive)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && transform.position.y < myGameManager.levelConstraintTop)
            {
                transform.Translate(new Vector2(0, 1.25f));
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && transform.position.y > myGameManager.levelConstraintBottom) 
            {
                transform.Translate(new Vector2(0, -1.25f));
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) && transform.position.x > myGameManager.levelConstraintLeft)
            {
                transform.Translate(new Vector2(-1.25f, 0));
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && transform.position.x < myGameManager.levelConstraintRight)
            {
                transform.Translate(new Vector2(1.25f, 0));
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                GameObject vBullet = Instantiate(bullet, transform.position, transform.rotation);
                vBullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerIsAlive)
        {
            if (collision.transform.parent.GetComponent<Vehicle>() != null)
            {
                //myScore += "Score: " + 10; //update string of collision

                print("yes");
                playerIsAlive = false;
                playerCanMove = false;
            }
        }
    }
    private bool calculateFinalScore()
    {
        //calculate all the given variables for scoring
        return false;
    }
}

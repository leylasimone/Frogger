using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    private Vector3 _lastpos;
    private bool _onLilypad = false;

    public string playerName = ""; //The players name for the purpose of storing the high score
     
    public const int playerTotalLives = 10; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.

    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?

    private GameManager myGameManager; //A reference to the GameManager in the scene.

    private float _furthestY = -6.4f;

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
                transform.Translate(new Vector2(0, 1f));
                if (transform.position.y > _furthestY)
                {
                    _furthestY = this.transform.position.y;
                    Score.CurrentScore += 10;
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && transform.position.y > myGameManager.levelConstraintBottom) 
            {
                transform.Translate(new Vector2(0, -1f));
                if (transform.position.y < -6.4)
                {
                    transform.position = new Vector2(transform.position.x, -6.4f);
                }                                
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) && transform.position.x > myGameManager.levelConstraintLeft)
            {
                transform.Translate(new Vector2(-1f, 0));
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && transform.position.x < myGameManager.levelConstraintRight)
            {
                transform.Translate(new Vector2(1f, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detect collisions between the GameObjects with Colliders attached
        if (playerIsAlive)
        {
            //Check for a match with the specified tag on any GameObject that collides with your GameObject

            if (collision.gameObject.name.Contains("lily pad"))
            {
                _onLilypad = true;
                _lastpos = this.transform.position;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider" && _onLilypad == false)
        {
            //death ui
            Score.CurrentScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //score change
            //Score goes down
            //myScore += "Score: " + 10; //update string of collision
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
      //Debug.Log(collision.gameObject.name);
      if (collision.gameObject.name.Contains("lily pad"))
      {
        if (this.transform.position == _lastpos)
        {
            this.transform.position += new Vector3((collision.gameObject.GetComponent<LilyPad>().moveDirection ? 1 : -1), 0, 0);

        }
        else
        {
            _onLilypad = false;
        }
      }
    }

    private bool calculateFinalScore()
    {
        //calculate all the given variables for scoring
        return false;
    }
}


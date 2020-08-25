using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

/// <summary>
/// This script must be utlised as the core component on the 'vehicle' obstacle in the frogger game.
/// </summary>
public class Vehicle : MonoBehaviour
{
    /// -1 = left, 1 = right
    public int moveDirection = 0; //This variabe is to be used to indicate the direction the vehicle is moving in.
    public float speed; //This variable is to be used to control the speed of the vehicle.
    public Vector2 startingPosition; //This variable is to be used to indicate where on the map the vehicle starts (or spawns)
    public Vector2 endPosition; //This variablle is to be used to indicate the final destination of the vehicle.
    public bool reverseOrder = false; //when true switch endposition and start position

    // Start is called before the first frame update
    void Start()
    {
        if (reverseOrder == true)
        {
            Vector2 temp = endPosition;
            endPosition = startingPosition;
            startingPosition = temp;
        }

        this.transform.position = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(reverseOrder)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed * moveDirection);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveDirection);
        }
        //when you multiply the inequality on both sides by -1 (or divide by -1) the inequality changes
        if ((transform.position.x * moveDirection) > (endPosition.x * moveDirection))
        {
            transform.position = startingPosition;
        }
    }

}

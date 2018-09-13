using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;

    void Start()
    {
        m_GravityDirection = GravityDirection.Down;
    }

    void FixedUpdate()
    {
        switch (m_GravityDirection)
        {
            

            case GravityDirection.Left:
                //Change the gravity to go to the left
                Physics2D.gravity = new Vector2(-2f, 0);
                //Press the space key to change the direction of gravity
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_GravityDirection = GravityDirection.Up;
                    Debug.Log("Up");
                }
                break;

            case GravityDirection.Up:
                //Change the gravity to be in a upward direction
                Physics2D.gravity = new Vector2(0, 2f);
                //Press the space key to change the direction
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_GravityDirection = GravityDirection.Right;
                    Debug.Log("Right");
                }
                break;

            case GravityDirection.Right:
                //Change the gravity to go in the right direction
                Physics2D.gravity = new Vector2(2f, 0);
                //Press the space key to change the direction
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_GravityDirection = GravityDirection.Down;
                    Debug.Log("Down");
                }

                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Detect Swipe -> Move
//loop through to check which object is collided with
//Detect collision->if collides with another puzzle piece
//Swap position
//Reset current position

public class TouchController : MonoBehaviour
{
    Empty_Movement empty_Movement;
    
    private Vector2 startPos;
    public int pixelDisToDetect = 20;
    private bool fingerDown;
    private int movingDirection;

    private Vector3 emptyCurrentLocation;
    private Vector3 emptyNewLocation;

    private void Start()
    {
        //This is the gameobject which has mesh renderer turned off and will
        //swap position with any puzzle piece it touches.
        empty_Movement = GameObject.Find("Empty_Space").GetComponent<Empty_Movement>();
    }
    public void swipeDetection()
    {
        //////////////////////////////////////////////////////////////
        ///TOUCH INPUT

        //if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    startPos = Input.touches[0].position;
        //    fingerDown = true;
        //}

        //if (fingerDown)
        //{
        //    if (Input.touches[0].position.x >= startPos.x + pixelDisToDetect)
        //    {
        //        Debug.Log("swiping right");
        //        fingerDown = false;
                
        //    }
        //    else if (Input.touches[0].position.x <= startPos.x - pixelDisToDetect)
        //    {
        //        Debug.Log("swiping left");
        //        fingerDown = false;

        //    }
        //    else if (Input.touches[0].position.y >= startPos.y + pixelDisToDetect)
        //    {
        //        Debug.Log("swiping up");
        //        fingerDown = false;

        //    }
        //    else if (Input.touches[0].position.y <= startPos.y - pixelDisToDetect)
        //    {
        //        Debug.Log("swiping Down");
        //        fingerDown = false;

        //    }
        //}

        /////////////////////////////////////////////////////////////////////


        //TESTING WITH MOUSE
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown)
        {
            //SWIPE RIGHT//

            if (Input.mousePosition.x >= startPos.x + pixelDisToDetect)
            {
                fingerDown = false;
                empty_Movement.Movement(1);
            }

            //SWIPE LEFT//
            else if (Input.mousePosition.x <= startPos.x - pixelDisToDetect)
            {
                fingerDown = false;
                empty_Movement.Movement(3);
            }

            //SWIPE UP//
            else if (Input.mousePosition.y >= startPos.y + pixelDisToDetect)
            { 
                fingerDown = false;
                empty_Movement.Movement(0);
            }

            //SWIPE Down//
            else if (Input.mousePosition.y <= startPos.y - pixelDisToDetect)
            {
                fingerDown = false;
                empty_Movement.Movement(2);
            }
        }

        //WHEN LIFTING mouse-click
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }


    }
    void Update()
    {
        //Will check for swipes every frame.
        swipeDetection();
    }
}

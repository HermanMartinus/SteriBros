using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


    public float Player1X = 0;
    public float Player2X = 0;

    public static Controller Instance;

    // Use this for initialization
    void Awake () {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width /2f )
        {
            Player1X = Clamp((Input.mousePosition.x / (Screen.width / 2) - 0.5f) * 2);
        }
        else
        {
            Player1X = 0;
        }

        if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2f)
        {
            Player2X = Clamp((Input.mousePosition.x / (Screen.width / 2) - 1.5f) * 2);
        }
        else
        {
            Player2X = 0;
        }

        MobileController();
    }

    void MobileController()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                //For left half screen
                if (touch.phase == TouchPhase.Began && touch.position.x <= Screen.width / 2)
                {
                    Player1X = Clamp((Input.mousePosition.x / (Screen.width / 2) - 0.5f) * 2);
                }
                //For right half screen
                if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width)
                {
                    Player2X = Clamp((Input.mousePosition.x / (Screen.width / 2) - 1.5f) * 2);
                }
                if (touch.phase == TouchPhase.Ended)
                { //correct end of touch
                    //if (touch.fingerId == finId1)
                    //{ //check id finger for end touch
                    //    finId1 = -1;
                    //}
                    //else if (touch.fingerId == finId2)
                    //{
                    //    finId2 = -1;
                    //}
                }
            }
        }
    }

    float Clamp(float input)
    {
        //if(input > 1 || input < -1)
        //{
        //    return 0;
        //}
        if (input > 0)
            return 1;
        else
            return -1;
        //return input;
    }
}

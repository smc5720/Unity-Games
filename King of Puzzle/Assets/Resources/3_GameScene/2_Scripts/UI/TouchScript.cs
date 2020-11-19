using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour
{
    int BeganX, BeganY;
    int EndedX, EndedY;
    BallSingleTon BallMng;
    bool StartState;
    bool EndState;

    // Use this for initialization
    void Start()
    {
        BallMng = BallSingleTon.I;
        BeganX = 0;
        BeganY = 0;
        EndedX = 0;
        EndedY = 0;
        StartState = false;
        EndState = false;
    }

    // Update is called once per frame
    void Update()
    {
        TouchCheck();
    }

    void TouchCheck()
    {
        int cnt = Input.touchCount;

        for (int i = 0; i < cnt; ++i)
        {
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                BeganX = (int)pos.x;
                BeganY = (int)pos.y;
                StartState = true;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                EndedX = (int)pos.x;
                EndedY = (int)pos.y;
                EndState = true;
            }

            if (StartState == true && EndState == true)
            {
                if (Mathf.Abs(BeganX - EndedX) > Mathf.Abs(BeganY - EndedY))
                {
                    if (BeganX > EndedX)
                    {
                        BallMng.LeftBtn();
                        StartState = false;
                        EndState = false;
                    }

                    else if ((BeganX < EndedX))
                    {
                        BallMng.RightBtn();
                        StartState = false;
                        EndState = false;
                    }

                    else
                    {
                        StartState = false;
                        EndState = false;
                    }
                }

                else if (Mathf.Abs(BeganX - EndedX) < Mathf.Abs(BeganY - EndedY))
                {
                    if (BeganY > EndedY)
                    {
                        BallMng.DownBtn();
                        StartState = false;
                        EndState = false;
                    }

                    else if (BeganY < EndedY)
                    {
                        BallMng.UpBtn();
                        StartState = false;
                        EndState = false;
                    }

                    else
                    {
                        StartState = false;
                        EndState = false;
                    }
                }

                else
                {
                    StartState = false;
                    EndState = false;
                }
            }
        }
    }
}
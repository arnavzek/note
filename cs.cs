using System.Collections.Generic;
using UnityEngine;

public class AndroidControl : MonoBehaviour
{
    Rigidbody2D rb;

    SpringJoint2D spring;
    private Vector3 touchPosition;

    Vector3 anchorLimit;
    bool clicked;
    public float stretchLimit;

    bool isClose;
    Vector3 anchorCurrent;
    public float closeLimit;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        isClose = false;
        // spring.enabled = false;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began )//&& touchPosition == transform.position)
            {
                anchorCurrent = transform.position;
                
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Moved");
                Debug.Log(anchorCurrent);
                if (Vector3.Distance(touchPosition, anchorCurrent) > stretchLimit)
                {
                    
                    Vector3 touchpos = anchorCurrent + (touchPosition - anchorCurrent).normalized * stretchLimit;
                    rb.position = touchpos;
                }
                else
                {
                    rb.position = touchPosition;
                }
            }
            /*   if (touch.phase == TouchPhase.Ended)
               {
                   MakeSpring();
               }*/
        }

    }
    void OnTouchDown()
    {
        
        Debug.Log("Touched");
    }

    void MakeSpring()
    {
        spring = gameObject.AddComponent<SpringJoint2D>();
        spring.anchor = anchorCurrent;


    }
} 
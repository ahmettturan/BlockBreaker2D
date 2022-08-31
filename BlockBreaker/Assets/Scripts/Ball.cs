using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallController 
{
public class Ball : MonoBehaviour
{
    //config params
   [SerializeField] PaddleController paddle1;
   [SerializeField] float ballLaunchX = 2f;
   [SerializeField] float ballLaunchY = 13f;
   bool hasStarted = false;
   

   //state
   Vector2 paddleToBallVector; 
   
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
          LockBallToPaddle();
          LaunchOnMouseClick();  
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
           hasStarted = true;
           GetComponent<Rigidbody2D>().velocity = new Vector2(ballLaunchX, ballLaunchY); 
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlePos + paddleToBallVector;
    }
}
}
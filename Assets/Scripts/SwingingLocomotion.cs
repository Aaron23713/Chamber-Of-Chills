using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwingingLocomotion : MonoBehaviour
{
    // Game Objects
    public GameObject LeftController;
    public GameObject RightController;
    public GameObject Camera;
    public GameObject Direction;

    //Vector3 Positions
    private Vector3 PositionPreviousFrameLeftController;
    private Vector3 PositionPreviousFrameRightController;
    private Vector3 PlayerPositionPreviousFrame;
    private Vector3 PlayerPositionCurrentFrame;
    private Vector3 PositionCurrentFrameLeftController;
    private Vector3 PositionCurrentFrameRightController;

    public float Speed;
    private float ControllerSpeed;

    public InputActionReference rightTrigger;
    public InputActionReference leftTrigger;
    public bool move = false;


    void Start()
    {
        /**
        Sets starting position of player and controllers.
        */
        PlayerPositionPreviousFrame = transform.position;
        PositionPreviousFrameLeftController = LeftController.transform.position;
        PositionPreviousFrameRightController = RightController.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        /**
        Checks to see if user is holding the triggers
        0.0f is when the trigger is not being held but if it is it should be greater than 0.0f
        */
        if (rightTrigger.action.ReadValue<float>() > 0.0f && leftTrigger.action.ReadValue<float>() > 0.0f)
        {
            /**
            Gets current position of player and  controllers
           */
            PositionCurrentFrameLeftController = LeftController.transform.position;
            PositionCurrentFrameRightController = RightController.transform.position;
            PlayerPositionCurrentFrame = transform.position;
            if (move == false)
            {
                move = true;
                /**
               Sets previous position of controllers and player to current position so that when the next update 
                is called there is now a new position and the it continuously progresses.
               */
                PositionPreviousFrameLeftController = PositionCurrentFrameLeftController;
                PositionPreviousFrameRightController = PositionCurrentFrameRightController;
                PlayerPositionPreviousFrame = PlayerPositionCurrentFrame;

            }
            /**
            Sets the direction to wherever the camera is currently facing(Says the direction im going to walk is
             in front of camera)
            */
            float yRotation = Camera.transform.eulerAngles.y;
            Direction.transform.eulerAngles = new Vector3(0, yRotation, 0);






            /**
            Gets the total distance controller and player have moved since last frame(update call)
            */
            var playerDistanceMoved = Vector3.Distance(PlayerPositionCurrentFrame, PlayerPositionPreviousFrame);
            var leftControllerDistanceMoved = Vector3.Distance(PositionPreviousFrameLeftController, PositionCurrentFrameLeftController);
            var rightControllerDistanceMoved = Vector3.Distance(PositionPreviousFrameRightController, PositionCurrentFrameRightController);

            /**
            Get controller speed by subtracting left controller distance moved by how much the player has moved
            and adding it with right controllers side.
            */
            ControllerSpeed = ((leftControllerDistanceMoved - playerDistanceMoved) + (rightControllerDistanceMoved - playerDistanceMoved));

            // if(Time.timeSinceLevelLoad > 1f)
            // {
            transform.position += Direction.transform.forward * ControllerSpeed * Speed * Time.deltaTime;
            // }


            /**
            Sets previous position of controllers and player to current position so that when the next update 
            is called there is now a new position and the it continuously progresses.
            */
            PositionPreviousFrameLeftController = PositionCurrentFrameLeftController;
            PositionPreviousFrameRightController = PositionCurrentFrameRightController;
            PlayerPositionPreviousFrame = PlayerPositionCurrentFrame;
        }
        else
        {
            move = false;
        }

    }
}
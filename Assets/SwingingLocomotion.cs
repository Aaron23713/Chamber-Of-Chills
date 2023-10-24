using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingLocomotion : MonoBehaviour
{
    // Start is called before the first frame update
 
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Camera;
    public GameObject forwardDirection;
    public float Speed = 70;
    private Vector3 PositionPreviousFrameLeftHand;
    private Vector3 PositionPreviousFrameRightHand;
    private Vector3 PlayerPositionPreviousFrame;
    private Vector3 PlayerPositionThisFrame;
    private Vector3 PlayerPositionThisFrameLeftHand;
    private Vector3 PlayerPositionThisFrameRightHand;
    private float HandSpeed;
    void Start()
    {
         PlayerPositionPreviousFrame = transform.position;
         PositionPreviousFrameLeftHand = LeftHand.transform.position;
         PositionPreviousFrameRightHand = RightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = Camera.transform.eulerAngles.y;
        forwardDirection.transform.eulerAngles = new Vector3(0,yRotation,0);

        PlayerPositionThisFrameLeftHand = LeftHand.transform.position;
        PlayerPositionThisFrameRightHand = RightHand.transform.position;
        PlayerPositionThisFrame = transform.position;

        var PlayerDistanceMoved = Vector3.Distance(PlayerPositionThisFrame,PlayerPositionPreviousFrame);
        var LeftHandDistanceMoved = Vector3.Distance(PositionPreviousFrameLeftHand,PlayerPositionThisFrameLeftHand);
        var RightHandDistanceMoved = Vector3.Distance(PositionPreviousFrameRightHand,PlayerPositionThisFrameRightHand);

        HandSpeed = ((LeftHandDistanceMoved - PlayerDistanceMoved) + (RightHandDistanceMoved - PlayerDistanceMoved));

        if(Time.timeSinceLevelLoad > 1f){
            transform.position += forwardDirection.transform.position * HandSpeed * Speed * Time.deltaTime;
            PositionPreviousFrameLeftHand = PlayerPositionThisFrameLeftHand;
            PositionPreviousFrameRightHand = PlayerPositionThisFrameRightHand;
            PlayerPositionPreviousFrame = PlayerPositionThisFrame;

        }
    }
}

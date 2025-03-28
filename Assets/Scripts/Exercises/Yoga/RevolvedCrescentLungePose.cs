using UnityEngine;
using UnityEngine.UI; // For UI elements

public class RevolvedCrescentLungePose : MonoBehaviour
{
    public Text feedbackText; // UI feedback for player

    private bool isLeftLegForward = false;
    private bool isRightLegForward = false;
    private bool isTwistingLeft = false;
    private bool isTwistingRight = false;
    private int poseCount = 0; // Count of completed poses
    private float twistThreshold = 0.7f; // Minimum tilt to count as a twist

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Detect torso twisting

        // Detect Forward Leg Position
        if (Input.GetKeyDown(KeyCode.JoystickButton10)) // Left Leg Forward
        {
            isLeftLegForward = true;
            isRightLegForward = false;
            feedbackText.text = "Left Leg Forward. Twist Your Torso!";
            Debug.Log("Left Leg Forward.");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton11)) // Right Leg Forward
        {
            isRightLegForward = true;
            isLeftLegForward = false;
            feedbackText.text = "Right Leg Forward. Twist Your Torso!";
            Debug.Log("Right Leg Forward.");
        }

        // Detect Twisting
        if ((horizontal <= -twistThreshold && isLeftLegForward) && !isTwistingLeft)
        {
            isTwistingLeft = true;
            feedbackText.text = "Twisting Left... Hold!";
            Debug.Log("Twisting Left.");
        }
        else if ((horizontal >= twistThreshold && isRightLegForward) && !isTwistingRight)
        {
            isTwistingRight = true;
            feedbackText.text = "Twisting Right... Hold!";
            Debug.Log("Twisting Right.");
        }

        // Confirm Pose Completion
        if ((isTwistingLeft && isLeftLegForward) || (isTwistingRight && isRightLegForward))
        {
            poseCount++;
            feedbackText.text = $"Revolved Crescent Lunge Complete! Total: {poseCount}";
            Debug.Log($"Revolved Crescent Lunge Complete. Total: {poseCount}");

            ResetPose();
        }
    }

    private void ResetPose()
    {
        isTwistingLeft = false;
        isTwistingRight = false;
        isLeftLegForward = false;
        isRightLegForward = false;
    }
}

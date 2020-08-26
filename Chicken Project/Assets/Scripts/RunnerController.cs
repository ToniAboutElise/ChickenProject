using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour
{
    public bool leftButtonPressed = false;
    public bool rightButtonPressed = false;
    public bool isRotating = false;
    public GameObject cylinder;
    public Button leftButton;
    public Button rightButton;
    public float playerRotationVelocity = 2.5f;
    public int currentPoints;
    public Text pointsText;

    protected void Rotation()
    {
        if(isRotating == false)
        { 
            if (Input.GetKey(KeyCode.LeftArrow) || leftButtonPressed == true)
            {
                cylinder.transform.Rotate(new Vector3(0,0,-playerRotationVelocity));
            }
            else if (Input.GetKey(KeyCode.RightArrow) || rightButtonPressed == true)
            {
                cylinder.transform.Rotate(new Vector3(0, 0, playerRotationVelocity));
            }
        }
    }

    public void UpdateCurrentPoints(int pointsToAdd)
    {
        currentPoints += pointsToAdd;
        pointsText.text = currentPoints.ToString();
    }

    public void TouchLeftPress()
    {
        leftButtonPressed = true;
    }

    public void TouchLeftRelease()
    {
        leftButtonPressed = false;
    }

    public void TouchRightPress()
    {
        rightButtonPressed = true;
    }

    public void TouchRightRelease()
    {
        rightButtonPressed = false;
    }

    private void Update()
    {
        Rotation();
    }
}

public class DifficultyLevel : MonoBehaviour
{
    public int freeSpaces;
    public float enemiesVelocity;
    public float playerRotationVelocity;
}
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
    public GameObject rushModeGameObject;
    public Button leftButton;
    public Button rightButton;
    public float playerRotationVelocity = 2.5f;
    public float spawnCooldown = 1;
    public int spawnRate = 3;
    public int currentPoints;
    public Text pointsText;

    private void Start()
    {
        rushModeGameObject.SetActive(false);
        StartCoroutine(AddGameVelocity());
    }

    protected IEnumerator AddGameVelocity()
    {
        yield return new WaitForSeconds(10);
        playerRotationVelocity += 0.1f;
        if(spawnCooldown > 0.6f)
        { 
            spawnCooldown -= 0.1f;
            StartCoroutine(AddGameVelocity());
        }
        else if (spawnCooldown > 0.5f)
        {
            spawnCooldown -= 0.2f;
            spawnRate = 6;
            rushModeGameObject.SetActive(true);
        }
    }

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
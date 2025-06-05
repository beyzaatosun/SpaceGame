using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float speed ;
    private float acceleration;
    float maxSpeed;
    bool isMoving ;
    
    void Start()
    {
        isMoving = true;
        if (Settings.GetEasyDifficulty() == 1)
        {
            speed = 0.3f;
            acceleration = 0.03f;
            maxSpeed = 1.5f;
        }
        if (Settings.GetMediumDifficulty() == 1)
        {
            speed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 2.0f;
        }
        if (Settings.GetHardDifficulty() == 1)
        {
            speed = 0.8f;
            acceleration = 0.08f;
            maxSpeed = 2.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MovingCamera();

        }
    }

    void MovingCamera()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void FinishGame()
    {
        isMoving = false;
    }
}

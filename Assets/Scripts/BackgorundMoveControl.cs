using UnityEngine;

public class BackgorundMoveControl : MonoBehaviour
{
    private float backgroundPosition;
    private float distance = 10.24f;
    void Start()
    {
        backgroundPosition = transform.position.y;
        FindObjectOfType<Planet>().PlacePlanet(backgroundPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundPosition + distance < Camera.main.transform.position.y)
        {
            SetBackground();
        }
    }

    void SetBackground()
    {
        backgroundPosition += (distance * 2);
        FindObjectOfType<Planet>().PlacePlanet(backgroundPosition);

        Vector2 newPositon = new Vector2(0, backgroundPosition);
        transform.position = newPositon;
    }
}

using UnityEngine;

public class ScreenCalculate : MonoBehaviour
{
    public static ScreenCalculate instance;
    private float height;
    float width;

    public float Height
    {
        get { return height; }
    }

    public float Width
    {
        get { return width; }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

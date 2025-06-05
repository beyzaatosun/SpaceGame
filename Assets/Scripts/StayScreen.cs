using UnityEngine;

public class StayScreen : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -ScreenCalculate.instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = -ScreenCalculate.instance.Width;
            transform.position = temp;
            
        }
        if (transform.position.x > ScreenCalculate.instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = ScreenCalculate.instance.Width;
            transform.position = temp;
            
        }
    }
}

using UnityEngine;

public class KillPlatform : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private float randomSpeed;
    private bool moving;
    private float min, max;

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float objectWidth = boxCollider2D.bounds.extents.x;
        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculate.instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculate.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float pingPongX = Mathf.PingPong(Time.time* randomSpeed, max-min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Foots")
        {
            FindObjectOfType<GameControl>().FinishGame();
        }
    }
}

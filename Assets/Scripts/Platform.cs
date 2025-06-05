using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    private PolygonCollider2D polygonCollider2D;
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
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        if (Settings.GetEasyDifficulty() == 1)
        {
            randomSpeed = Random.Range(0.2f, 0.8f);

        }
        if (Settings.GetMediumDifficulty() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1.0f);

        }
        if (Settings.GetHardDifficulty() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);

        }
        
        float objectWidth = polygonCollider2D.bounds.extents.x;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Foots")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMove>().RestJumpCount();
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab = default;
    [SerializeField] GameObject playerPrefab = default;
    [SerializeField] GameObject killPlatformPrefab = default;
    [SerializeField] private float distanceBetweenPlatforms =default;

    private List<GameObject> platforms = new List<GameObject>();
    private Vector2 platformPosition;
    private Vector2 playerPosition;
    private bool direction = true;

    void Start()
    {
        MakePlatform();
    }

    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + ScreenCalculate.instance.Height)
        {
            PlacePlatform();
        }
    }

    void MakePlatform()
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);
        
        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Moving = true;
        

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Moving = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Gold>().OpenGold();
            }
            NextPlatformPosition();
        }
        GameObject killPlatform = Instantiate(killPlatformPrefab, platformPosition, Quaternion.identity);
        killPlatform.GetComponent<KillPlatform>().Moving = true;
        platforms.Add(killPlatform);
        NextPlatformPosition();
    }

    void PlacePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i+5].transform.position = platformPosition;
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i+5].GetComponent<Gold>().CloseGold();
                float randomGold = Random.Range(0.0f, 1.0f);
                if (randomGold > 0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().OpenGold();
                }
            }
            NextPlatformPosition();
        }
    }
    void NextPlatformPosition()
    {
        platformPosition.y += distanceBetweenPlatforms;
        SequentialPosition();
    }

    void MixPosition()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculate.instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculate.instance.Width / 2;

        }
    }

    void SequentialPosition()
    {
        if (direction)
        {
            platformPosition.x = ScreenCalculate.instance.Width / 2;
            direction = false;
        }
        else
        {
            platformPosition.x = -ScreenCalculate.instance.Width / 2;
            direction = true;
            
        }
    }
}

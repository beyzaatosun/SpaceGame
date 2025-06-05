using Unity.Android.Gradle.Manifest;
using UnityEngine;
using Screen = Unity.Android.Gradle.Manifest.Screen;

public class FullScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteWidth = spriteRenderer.size.x;
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight / UnityEngine.Screen.height * UnityEngine.Screen.width;
        tempScale.x = screenWidth / spriteWidth;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

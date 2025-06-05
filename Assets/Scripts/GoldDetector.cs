using System;
using UnityEngine;

public class GoldDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Foots")
        {
            GetComponentInParent<Gold>().CloseGold();
            FindObjectOfType<Score>().EarnGold();
        }
    }
}

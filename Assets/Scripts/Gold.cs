using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] GameObject goldN = default;

    public void OpenGold()
    {
        goldN.SetActive(true);
    }
    public void CloseGold()
    {
        goldN.SetActive(false);
    }       

}

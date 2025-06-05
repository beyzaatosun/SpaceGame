using UnityEngine;
using UnityEngine.UI;
public class SliderControl : MonoBehaviour
{
    Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;

    }

    public void SliderValue(int maxValue, int value)
    {
        int sliderValue = maxValue - value;
        slider.maxValue = maxValue;
        slider.value = sliderValue;
    }
}

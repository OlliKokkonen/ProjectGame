using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;

    Quaternion startRotation;

    public void Start()
    {
        startRotation = transform.rotation;
    }

    public void Update()
    {
        transform.rotation = startRotation;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}

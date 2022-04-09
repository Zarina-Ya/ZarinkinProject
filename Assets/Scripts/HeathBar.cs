using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }
    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}

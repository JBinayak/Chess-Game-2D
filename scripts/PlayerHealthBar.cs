using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float currHealth, float maxHealth)
    {
        slider.value = currHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

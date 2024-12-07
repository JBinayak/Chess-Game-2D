using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float currHealth, float maxHealth) 
    {
        slider.value = currHealth / maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDController : MonoBehaviour
{
    public Image healthBar;
    public Image fuelBar;
    public Text capacityText;

    public float currentHealth;

    public float currentFuel;
    public float fuelLossRate;

    public int maxCapacity;
    public int currentCapacity;


    private void Start()
    {
        currentHealth = 1;
        currentFuel = 1;
        currentCapacity = 0;
    }

    private void Update()
    {
        healthBar.fillAmount = currentHealth;
        fuelBar.fillAmount = currentFuel;
        capacityText.text = string.Format("Capacity: {0}/{1}", currentCapacity, maxCapacity);
    }

}

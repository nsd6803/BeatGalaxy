using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LifeManager : MonoBehaviour
{
    public PlanetHealth planetHealth;
    public TMP_Text healthText;

    private void Start()
    {
        planetHealth = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetHealth>();
        healthText = GetComponentInChildren<TMP_Text>(); // �������������� ���� coinText � ������� ������ GetComponentInChildren
    }

    void Update()
    {
        healthText.text = planetHealth.pl_health.ToString();
    }
}

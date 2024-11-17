using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHealthBar : MonoBehaviour
{
    [SerializeField] private bool reset = false;
    [SerializeField] private float maxHealt = 100;
    [SerializeField] private float currentHealt;
    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealt;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reset)
        {
            reset = false;
            currentHealt = maxHealt;
            healthBar.UpdateHealthBar(maxHealt, currentHealt);
            return;
        }
        currentHealt -= 1f;
        healthBar.UpdateHealthBar(maxHealt, currentHealt);

    }
}

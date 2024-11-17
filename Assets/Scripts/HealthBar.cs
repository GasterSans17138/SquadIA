using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;

    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    public void UpdateHealthBar(float _maxHealth, float _currentHealth)
    {
        healthBarSprite.fillAmount = _currentHealth / _maxHealth;

        if(_currentHealth > _maxHealth * 0.66f)
            healthBarSprite.color = new Color(0.176f, 0.851f, 0.153f);
        else if(_currentHealth > _maxHealth * 0.33f)
            healthBarSprite.color = new Color(0.851f, 0.612f, 0.153f);
        else
            healthBarSprite.color = new Color(0.851f, 0.275f, 0.153f);
    }

    public void Reset()
    {
        healthBarSprite.fillAmount = 1f;
        healthBarSprite.color = new Color(0.176f, 0.851f, 0.153f);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}

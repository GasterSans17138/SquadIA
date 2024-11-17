using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public float playerSpeed = 2.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    [SerializeField] private LayerMask maskForClick;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) gameObject.transform.forward = move;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        transform.LookAt(GetPointToTarget());

        if (Input.GetMouseButtonDown(0)) shootComponent.StartShooting(true);

        PlayerNeedTacticalShoot.isRightClicked = Input.GetMouseButton(1);


        // Order is important for thoses 2 if
        if (Input.GetMouseButtonDown(2) && PlayerDefendedNowShootDecision.defending)
        {
            PlayerNeedDefendingDecision.isMiddleMouseButtonClicked = true;
        }

        if (Input.GetMouseButtonDown(2) && !PlayerDefendedNowShootDecision.defending)
        {
            PlayerNeedDefendingDecision.isMiddleMouseButtonClicked = true;
            PlayerDefendedNowShootDecision.defending = true;
        }
    }

    public Vector3 GetPointToTarget()
    {
        Vector3 scrPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(scrPosition);

        Vector3 worldPosition = Vector3.up;
        if(Physics.Raycast(ray, out RaycastHit hitData,1000, maskForClick))
        {
            worldPosition = hitData.point;
        }

        worldPosition.y = 1.66f;

        return worldPosition;
    }
}
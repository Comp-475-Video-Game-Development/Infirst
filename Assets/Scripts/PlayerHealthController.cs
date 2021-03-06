﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private bool isAttacking;

    private int maxHealth = 4;
    private int minHealth = 0;
    private int currentHealth = 4;

    private void Update()
    {
        isAttacking = FollowScript.IsAttacking;

        if (isAttacking)
        {
            --currentHealth;
            Debug.Log("lost 1 health");
        }

        if (currentHealth == minHealth)
        {
            // Player dead. Show game over.
            Debug.Log("You dead");
        }
    }
}
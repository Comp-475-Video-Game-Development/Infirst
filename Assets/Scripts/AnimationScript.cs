using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    private Transform enemyTransform;
    public GameObject player;
    private Animator anim;
    public int maxDistance;
    public float minDistance;
    public int moveSpeed;
    public int rotationSpeed;
    public static bool follow = false;
    public static bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
    }

    private bool isWalking = false;
    private bool isMoving = false;
    private static bool isAttacking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        enemyTransform = transform;
    }

    private void Update()
    {
        Debug.DrawLine(player.transform.position, enemyTransform.position, Color.yellow);

        if (follow)
        {
            if (Vector3.Distance(player.transform.position, enemyTransform.position) < maxDistance && Vector3.Distance(player.transform.position, enemyTransform.position) > minDistance)
            {
                isMoving = true;

                if (!isWalking)
                {
                    anim.ResetTrigger("Attack");
                    anim.SetTrigger("Walk");
                    isWalking = true;
                    isAttacking = false;
                }
            }
            else if (Vector3.Distance(player.transform.position, enemyTransform.position) <= minDistance)
            {
                if (!isAttacking)
                {
                    isAttacking = true;

                    anim.SetTrigger("Attack");
                    anim.ResetTrigger("Walk");
                    isMoving = false;
                    isWalking = false;
                }
            }
            else
            {
                isMoving = false;

                if (isWalking)
                {
                    isWalking = false;
                    isAttacking = false;
                    anim.SetTrigger("Idle");
                }

            }
        }
    }
}

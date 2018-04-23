using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

    private Transform enemyTransform;
    public GameObject player;
    private Animator anim;
    public int maxDistance;
    public float minDistance;
    public int moveSpeed;
    public int rotationSpeed;
    public static bool follow = false;
    private bool isWalking = false;
    private bool isMoving = false;
    private bool isAttacking = false;

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
                //Look at player
                Quaternion enemyRotation = Quaternion.Slerp(enemyTransform.rotation,
                Quaternion.LookRotation(player.transform.position - enemyTransform.position), rotationSpeed * Time.deltaTime);
                enemyRotation.x = 0;
                enemyRotation.z = 0;
                enemyTransform.rotation = (enemyRotation);


                //Move tward player
                //transform.LookAt(player.transform);
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

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

                if(isWalking)
                {
                    isWalking = false;
                    isAttacking = false;
                    anim.SetTrigger("Idle");
                }

            }

            
        }
    }
}

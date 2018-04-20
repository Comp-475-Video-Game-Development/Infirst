using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

    private Transform enemyTransform;
    public GameObject player;
    public int maxDistance;
    public int moveSpeed;
    public int rotationSpeed;
    

    private void Awake()
    {
        enemyTransform = transform;
    }


    private void Update()
    {
        Debug.DrawLine(player.transform.position, enemyTransform.position, Color.yellow);

        
        if(Vector3.Distance(player.transform.position, enemyTransform.position) < maxDistance)
        {
            //Look at player
            enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation,
            Quaternion.LookRotation(player.transform.position - enemyTransform.position), rotationSpeed * Time.deltaTime);

            //Move tward player
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}

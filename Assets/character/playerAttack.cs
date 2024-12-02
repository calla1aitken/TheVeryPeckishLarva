using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    //Assigns variables separately for both enemies
    public Transform enemy1;
    public Transform enemy2;
    public EnemyHealth enemyhealth1;
    public EnemyHealth enemyhealth2;
    public destroyPlatform movingPlatform;
    public LayerMask hitpointLayer1;
    public LayerMask hitpointLayer2;
    public bool onEnemy1 = false;
    public bool onEnemy2 = false;

    public Boolean enemy1dead;
    public Boolean enemy2dead;

    private void Start()
    {
        enemy1dead = false;
        enemy2dead = false;
    }

    private void Update()
    {

        //collison with each enemy hitpoint
        onEnemy1 = Physics2D.Raycast(transform.position, Vector2.down, 1, hitpointLayer1);
        onEnemy2 = Physics2D.Raycast(transform.position, Vector2.down, 1, hitpointLayer2);

        //enemies killed if player hit hitpoint
        if (onEnemy1 == true && Vector3.Distance(this.transform.position, enemy1.position)< 1f)
        {
            Debug.Log("Enemy 1 Dead");
            enemyhealth1.takeDamage();
            enemy1dead = true;
        }

        if (onEnemy2 == true && Vector3.Distance(this.transform.position, enemy2.position) < 1f)
        {
            Debug.Log("Enemy 2 Dead");
            enemyhealth2.takeDamage();
            enemy2dead = true;
        }

        //If both enemies are dead, platform disappears
        if ((enemy1dead == true) && (enemy2dead == true))
        {
            movingPlatform.OnDestroy();
        }
    }
 }




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    //Kills enemy
    public void takeDamage()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPlatform : MonoBehaviour
{
    public void OnDestroy()
    {
            Destroy(gameObject);
    }
}

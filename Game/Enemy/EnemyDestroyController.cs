using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyEnemy(float delay){
        Destroy(gameObject,delay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float _chanceOfCollectabledrop;
    private CollectableSpawner _collectableSpawner;
    private void Awake(){
        _collectableSpawner = FindObjectOfType<CollectableSpawner>();
    }
    public void RandomDropCollectable(){
        float range = Random.Range(0f,1f);
        if(_chanceOfCollectabledrop>range){
        _collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    
    [SerializeField]
    private Transform   _gunOffset;
    [SerializeField]
    private float   _timeBetweenShots;
    private float   _lastFireTime;
    private bool _firingContinuously;
    private bool _fireSingle;

    void Update()
    {
     if (_firingContinuously || _fireSingle)
     {
        float timeSinceLastFire = Time.time - _lastFireTime ;
        if(timeSinceLastFire >=_timeBetweenShots){
            FireBullet();
        _lastFireTime = Time.time;
        _fireSingle = false;
        }
     }   
    }
    
    private void FireBullet(){
        GameObject bullet = Instantiate(_bulletPrefab , _gunOffset.position , transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
    }
    private void OnFire (InputValue inputValue){
        _firingContinuously = inputValue.isPressed;

        if(inputValue.isPressed){
            _fireSingle = true;
        }

    }
}

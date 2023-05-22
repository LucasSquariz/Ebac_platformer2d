using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform prefabProjectile;

    public Transform positionToShoot;
    public Transform projectileParent;
    public float timeBetweenShoot = .05f;
    public Transform playerSideReference;

    private Coroutine _currentCorrotine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentCorrotine = StartCoroutine(StartShoot());
        } 
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (_currentCorrotine != null)
            {
                StopCoroutine(_currentCorrotine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile, projectileParent);
        projectile.transform.position = positionToShoot.position;
        projectile.GetComponentInChildren<ProjectileBase>().side = playerSideReference.transform.localScale.x;
    }
}

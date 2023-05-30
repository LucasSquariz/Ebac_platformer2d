using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform prefabProjectile;

    public Transform positionToShoot;
    internal Transform projectileParent;
    public float timeBetweenShoot = .05f;
    public Transform playerSideReference;

    private Coroutine _currentCorrotine;
    public AudioRandomPlayAudioClips randomShoots;

    private void Awake()
    {
        playerSideReference = GameObject.FindObjectOfType<Player>().transform;
        
    }
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
        if(randomShoots != null)
        {
            randomShoots.PlayRandom();
        }
        var projectile = Instantiate(prefabProjectile, projectileParent);
        projectile.transform.position = positionToShoot.position;
        projectile.GetComponentInChildren<ProjectileBase>().side = playerSideReference.transform.localScale.x;
    }
}

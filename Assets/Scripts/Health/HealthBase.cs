using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;
    public bool isDead = false;

    [SerializeField] private FlashColors _flashColor;

    public float delayOnKill = 0f;
    private int _currentLife;

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColors>();
        }
    }

    private void Init()
    {
    isDead = false;
    _currentLife = startLife;
    }


    public void Damage(int Damage)
    {
        if (isDead) return;
        _currentLife -= Damage;

        if (_currentLife <= 0 )
        {
            Kill();
        }

        if(_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        isDead = true;

        if ( destroyOnKill )
        {
            Destroy(gameObject, delayOnKill);
        }
    }
}

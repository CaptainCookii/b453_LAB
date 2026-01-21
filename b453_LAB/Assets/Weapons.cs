using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float bulletCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Reload()
    {

    }
}

using TMPro;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected TextMeshProUGUI mainUI;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float bulletCount;
    protected float currentBulletCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        currentBulletCount = bulletCount;
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Reload()
    {
        if (currentBulletCount != bulletCount)
        {
            currentBulletCount = bulletCount;
        }
    }

    protected virtual void displayAmmo()
    {

    }
}

using UnityEngine;

public class Pistol : Weapons
{
    protected override void Start()
    {
        base.Start();
        firePoint = transform.Find("Firepoint").transform;
    }

    public void shootPub()
    {
        Shoot();
    }

    public void reloadPub()
    {
        Reload();
    }

    public void displayPub()
    {
        displayAmmo();
    }
    protected override void Shoot()
    {
        if (currentBulletCount != 0)
        {
            currentBulletCount--;

            Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * range;
            Vector3 shootDirection = (targetPosition - firePoint.position).normalized;

            Debug.DrawRay(firePoint.position, shootDirection * range, Color.red, 1f);

            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, shootDirection, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    protected override void displayAmmo()
    {
        base.displayAmmo();
        mainUI.text = $"{currentBulletCount} / {bulletCount}";
    }
}

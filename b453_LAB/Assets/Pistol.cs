using UnityEngine;

public class Pistol : Weapons
{
    protected override void Start()
    {
        base.Start();
        firePoint = transform.Find("Firepoint").transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
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

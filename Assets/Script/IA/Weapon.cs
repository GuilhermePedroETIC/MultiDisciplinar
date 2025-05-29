using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private TypeOfWeapon typeOfWeapon;
    [SerializeField] private Arrow arrowPreFab;
    [SerializeField] private BulletWizard bulletWizardPreFab;
    [SerializeField] private grenade grenadePreFab;
    [SerializeField] private BulletRifle bulletRiflePreFab;


    private IaCharacther iaCharacther;

    private void Awake()
    {
        iaCharacther = GetComponentInParent<IaCharacther>();
    }

    private void Update()
    {
        if (typeOfWeapon == TypeOfWeapon.Bow)
        {
            if (iaCharacther.IsAttacking == true)
            {
                if (!IsInvoking("MakingArrow"))
                {
                    ShootArrow();
                }
            }
            else if (iaCharacther.IsAttacking == false)
            {
                StopShootArrow();
            }
        }
        else if (typeOfWeapon == TypeOfWeapon.Wand)
        {
            if(iaCharacther.IsAttacking == true)
            {
                if (!IsInvoking("MakingWand"))
                {
                    ShootWand();
                }
            }
            else if (iaCharacther.IsAttacking == false)
            {
                StopWand();             
            }
        }
        if (typeOfWeapon == TypeOfWeapon.Grenade)
        {
            if (iaCharacther.IsAttacking == true)
            {
                if (!IsInvoking("MakingGrenade"))
                {
                    ShootGrenade();
                }
            }
            else if (iaCharacther.IsAttacking == false)
            {
                StopGrenade();
            }
        }
        if (typeOfWeapon == TypeOfWeapon.Rifle)
        {
            if (iaCharacther.IsAttacking == true)
            {
                if (!IsInvoking("MakingBulletRifle"))
                {
                    ShootBulletRifle();
                }
            }
            else if (iaCharacther.IsAttacking == false)
            {
                StopBulletRifle();
            }
        }
        else if (typeOfWeapon == TypeOfWeapon.None)
        {
            CancelInvoke("ShootArrow");
            CancelInvoke("ShootWand");
        }
    }
    private void MakingArrow()
    {
        Quaternion offset = Quaternion.Euler(0, -90, 90);
        Quaternion newRot = transform.rotation * offset;
        Arrow arrow = Instantiate(arrowPreFab, transform.position, newRot);
       // Arrow arrow = Instantiate(arrowPreFab, transform.position, transform.rotation);

    }
    private void MakingWand()
    {
        BulletWizard bullet = Instantiate(bulletWizardPreFab, transform.position, Quaternion.identity);
        bullet.SetDirection(transform.forward);
    }
    private void MakingGrenade()
    {
        Quaternion offset = Quaternion.Euler(0, -90, 90);
        Quaternion newRot = transform.rotation * offset;
        grenade bullet = Instantiate(grenadePreFab, transform.position, newRot);
    }
    private void MakingBulletRifle()
    {
        Quaternion offset = Quaternion.Euler(0, -90, 90);
        Quaternion newRot = transform.rotation * offset;
        BulletRifle bullet = Instantiate(bulletRiflePreFab, transform.position, newRot);
    }

    private void ShootArrow()
    {
        InvokeRepeating("MakingArrow", 1f, 1f);
    }
    private void StopShootArrow()
    {
        CancelInvoke("MakingArrow");
    }

    private void ShootWand()
    {
        InvokeRepeating("MakingWand", 1.5f, 1.5f);
    }

    private void StopWand()
    {
        CancelInvoke("MakingWand");
    }

    private void ShootGrenade()
    {
        InvokeRepeating("MakingGrenade", 2, 2);
    }
    private void StopGrenade()
    {
        CancelInvoke("MakingGranade");
    }
    private void ShootBulletRifle()
    {
        InvokeRepeating("MakingBulletRifle", 1, 1);
    }
    private void StopBulletRifle()
    {
        CancelInvoke("MakingBulletRifle");
    }
    private enum TypeOfWeapon
    {
        None,
        Bow,
        Wand,
        Grenade,
        Rifle
    }
}

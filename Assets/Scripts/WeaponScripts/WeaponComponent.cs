using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None, Pistol, AssualtRifle
}

public enum WeaponFiringPattern
{
    SemiAuto, FullAuto, ThreeShotBurst, FiveShotBurst
}
[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public bool Repeating;
    public LayerMask weaponHitLayer;
   public WeaponFiringPattern WeaponFiringPattern;
    }
public class WeaponComponent : MonoBehaviour
{
    public Transform gripLoction;
    protected WeaponHolder WeaponHolder;

    [SerializeField]
    public WeaponStats weaponStats;

    public bool isFiring = false;
    public bool isReloading = false;

   protected Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Initialized(WeaponHolder _weaponHolder)
	{
        WeaponHolder = _weaponHolder;
	}

    public virtual void StartFiringWeapon()
	{
        isFiring = true;
        if (weaponStats.Repeating)
        {
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }
    }

    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
    }
    protected virtual void FireWeapon()
	{
        print("Firing weapon");
        weaponStats.bulletsInClip--;
	}
}

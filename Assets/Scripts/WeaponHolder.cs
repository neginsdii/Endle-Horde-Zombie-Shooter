using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    GameObject weaponToSpawn;
    public PlayerController playerController;
    Animator animator;
    Sprite crossHairImage;
    WeaponComponent equippedWeapon;
    [SerializeField]
    GameObject WeaponSocket;
    [SerializeField]
    Transform GripSocketLocation;

    bool WasFiring = false;
    bool FiringPressed = false;
    public readonly int isFiringHash = Animator.StringToHash("isFiring");
    public readonly int isReloadingHash = Animator.StringToHash("isReloading");
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        GameObject spawnWeapon = Instantiate(weaponToSpawn, WeaponSocket.transform.position, WeaponSocket.transform.rotation, WeaponSocket.transform);
        animator = GetComponent<Animator>();

        equippedWeapon = spawnWeapon.GetComponent<WeaponComponent>();
        equippedWeapon.Initialized(this);

        GripSocketLocation = equippedWeapon.gripLoction;
    }


    void Update()
    {
        
    }

	private void OnAnimatorIK(int layerIndex)
	{
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, GripSocketLocation.transform.position);
	}

    public void OnFire(InputValue value)
    {
        FiringPressed = value.isPressed;
        if(FiringPressed)
		{
            StartFiring();
		}
        else
		{
            StopFiring();
		}
  

    }
    public void OnReload(InputValue value)
    {
        playerController.isReloading = value.isPressed;
        animator.SetBool(isReloadingHash, playerController.isReloading);
    }

    public void StartFiring()
    {
        if (equippedWeapon.weaponStats.bulletsInClip <= 0) return;
        animator.SetBool(isFiringHash,true);
        playerController.isFiring = true;
        equippedWeapon.StartFiringWeapon();
    }

    public void StopFiring()
    {
        animator.SetBool(isFiringHash, false);
        playerController.isFiring = false;
        equippedWeapon.StopFiringWeapon();
    }

    public void StartReloading()
    {

    }
}

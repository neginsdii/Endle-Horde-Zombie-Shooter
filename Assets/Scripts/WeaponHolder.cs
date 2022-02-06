using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    GameObject weaponToSpawn;
    PlayerController playerController;
    Animator animator;
    Sprite crossHairImage;
    WeaponComponent equippedWeapon;
    [SerializeField]
    GameObject WeaponSocket;
    [SerializeField]
    Transform GripSocketLocation;
    void Start()
    {
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
}

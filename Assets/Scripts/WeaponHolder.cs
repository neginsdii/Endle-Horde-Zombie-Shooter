using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    GameObject weaponToSpawn;
    PlayerController playerController;
    Sprite crossHairImage;
    [SerializeField]
    GameObject WeaponSocket;
    void Start()
    {
        GameObject spawnWeapon = Instantiate(weaponToSpawn, WeaponSocket.transform.position, WeaponSocket.transform.rotation, WeaponSocket.transform); 
    }


    void Update()
    {
        
    }
}

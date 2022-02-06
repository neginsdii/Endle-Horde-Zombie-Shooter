using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    public Transform gripLoction;
    protected WeaponHolder WeaponHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Initialized(WeaponHolder _weaponHolder)
	{
        WeaponHolder = _weaponHolder;
	}
}

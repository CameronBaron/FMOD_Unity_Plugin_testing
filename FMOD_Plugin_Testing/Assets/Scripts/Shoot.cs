using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	[FMODUnity.EventRef]
	public string shoot = "event:/Pickup_1";

	public GameObject bulletPrefab;
	public GameObject bulletSpawn;
	public float bulletSpeed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			FMODUnity.RuntimeManager.PlayOneShot(shoot);
			GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
		}
	}

}

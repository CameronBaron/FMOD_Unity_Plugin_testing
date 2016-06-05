using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	[FMODUnity.EventRef]
	public string shoot = "event:/Pickup_1";

	public GameObject bulletPrefab;
	public float bulletSpeed;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0) && Time.timeScale > 0)
		{
			// Create new event instance
			FMOD.Studio.EventInstance fire = FMODUnity.RuntimeManager.CreateInstance(shoot);
			// Set 3D attributes  so that the sound comes from this gameObjects position in the world.
			fire.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
			fire.start();
			fire.release();
			// Release can be called straight away and the event will be disposed of when the event ends.
			
			// Create a new bullet.
			GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
			// Add a launch speed to bullet.
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
		}
	}

}

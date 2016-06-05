using UnityEngine;
using System.Collections;

public class hitSound : MonoBehaviour
{
	[FMODUnity.EventRef]
	public string impactSound = "Event:/ImpactSound";
	FMOD.Studio.EventInstance impactEv;

	float HitVel;

	// Use this for initialization
	void Start ()
	{
		impactEv = FMODUnity.RuntimeManager.CreateInstance(impactSound);
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision)
	{
		// Set impact sound position for 3D effect.
		impactEv.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
		// Start the event.
		impactEv.start();
		// Release event, allowing it to play until end.
		impactEv.release();
		Destroy(gameObject);
	}
}
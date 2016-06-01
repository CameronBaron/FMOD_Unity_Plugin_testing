using UnityEngine;
using System.Collections;

public class hitSound : MonoBehaviour
{
	[FMODUnity.EventRef]
	public string impactSound = "Event:/ImpactSound";
	FMOD.Studio.EventInstance impactEv;
	FMOD.Studio.ParameterInstance Intensity;

	Rigidbody rb;

	float HitVel;

	// Use this for initialization
	void Start ()
	{

		rb = GetComponent<Rigidbody>();

		impactEv = FMODUnity.RuntimeManager.CreateInstance(impactSound);
		FMOD.RESULT result = impactEv.getParameter("Size", out Intensity);
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision)
	{
		if (Intensity.isValid())
		{
			HitVel = (collision.relativeVelocity.magnitude);
			HitVel = HitVel / 20;

			FMOD.RESULT result = Intensity.setValue(HitVel);

			if (collision.gameObject.CompareTag("Ground"))
			{
				Debug.Log("ground");
			}
			else
			{
				Debug.Log("cube");
			}
		}

		impactEv.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
		impactEv.start();
		impactEv.release();
		Destroy(gameObject);
	}
}
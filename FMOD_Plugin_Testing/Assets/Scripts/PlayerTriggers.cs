using UnityEngine;
using System.Collections;

public class PlayerTriggers : MonoBehaviour
{
	Rigidbody rb;                   // Rigidbody ref

	[FMODUnity.EventRef]
	 public string music = "event:/Tune";
	 FMOD.Studio.EventInstance musicEvent;			// cube event music
	 FMOD.Studio.ParameterInstance musicEndParam;   // end param object (for transitioning to the end of music)

	[FMODUnity.EventRef]
	public string inputSound = "event:/Input_1";

	[FMODUnity.EventRef]
	public string reverbSnapshot = "event:/Reverb";
	FMOD.Studio.EventInstance reverbSnapshotEvent;

	FMOD.RESULT result;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		// Create FMOD instances and get parameters here
		musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);
		//musicEvent.getParameter("end", out musicEndParam);

		reverbSnapshotEvent = FMODUnity.RuntimeManager.CreateInstance(reverbSnapshot);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		/* If colliding with cubes */
		if (other.gameObject.CompareTag("Pickup"))
		{
			FMODUnity.RuntimeManager.PlayOneShot(inputSound);
		}

		if (other.gameObject.CompareTag("Playcube"))
		{
			FMOD.Studio.PLAYBACK_STATE play_state;
			musicEvent.getPlaybackState(out play_state);
			if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING)
			{
				//musicEndParam.setValue(0);
				musicEvent.start();
				other.GetComponent<Renderer>().material.color = Color.green;
			}
		}

		if (other.gameObject.CompareTag("Stopcube"))
		{
			// When collision with stop cube occurs, transition to the end of the event music
			//musicEndParam.setValue(1);
			musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			other.GetComponent<Renderer>().material.color = Color.black;
			// Release song if it is not needed again anytime soon
			//musicEvent.release();
		}

		if (other.gameObject.CompareTag("Killcube"))
		{
			// When collision with stop cube occurs, immediately stop event music
			musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			other.GetComponent<Renderer>().material.color = Color.red;
			// Release song if it is not needed again anytime soon
			//musicEvent.release();
		}

		/* check for reverb zone */
		if (other.gameObject.CompareTag("ReverbZone"))
		{
			other.GetComponent<Renderer>().material.color = Color.red;
			
			reverbSnapshotEvent.start();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("ReverbZone"))
		{
			other.GetComponent<Renderer>().material.color = Color.green;
			reverbSnapshotEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		}
	}
}

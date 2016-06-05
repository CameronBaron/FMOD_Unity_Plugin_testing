using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggers : MonoBehaviour
{							
	[FMODUnity.EventRef]							// Shows the following line in unity's editor with FMOD functionality.
	 public string music = "event:/Tune";			// The path to the sound to use.
	 FMOD.Studio.EventInstance musicEvent;			// event music.
	 FMOD.Studio.ParameterInstance musicEndParam;   // end param object (for transitioning to the end of music).

	[FMODUnity.EventRef]
	public string inputSound = "event:/Input_1";    // Sounds that are played as a oneshot do not need an event instance.
													// Although you cannot modify any parameters before playing this way.

	[FMODUnity.EventRef]
	public string reverbSnapshot = "event:/Reverb";
	FMOD.Studio.EventInstance reverbSnapshotEvent;

	public Text soundEffectDisplayText;

	void Start ()
	{
		// Create FMOD instances and get parameters here.
		//musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);

		//musicEvent.getParameter("end", out musicEndParam);
		reverbSnapshotEvent = FMODUnity.RuntimeManager.CreateInstance(reverbSnapshot);		
	}

	void OnTriggerEnter(Collider other)
	{
		/* If colliding with cubes */
		if (other.gameObject.CompareTag("Pickup"))
		{
			// Playing one shot sound, will play the sound to end and then destroy(?) itself.
			FMODUnity.RuntimeManager.PlayOneShot(inputSound);
		}	

		/* check for reverb zone */
		if (other.gameObject.CompareTag("ReverbZone"))
		{
			// Snapshots are started and stopped just like other events.
			reverbSnapshotEvent.start();
			soundEffectDisplayText.text = "Cave";
		}

		if (other.gameObject.CompareTag("Reverb2"))
		{
			// Snapshots are started and stopped just like other events.
			reverbSnapshotEvent.start();
			soundEffectDisplayText.text = "PaddedRoom";
		}
	}

	// OnTriggerExit to turn off the ReverbZone
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("ReverbZone"))
		{
			reverbSnapshotEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			soundEffectDisplayText.text = "n/a";
		}
		if (other.gameObject.CompareTag("Reverb2"))
		{
			// Snapshots are started and stopped just like other events.
			reverbSnapshotEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			soundEffectDisplayText.text = "n/a";
		}
	}
}

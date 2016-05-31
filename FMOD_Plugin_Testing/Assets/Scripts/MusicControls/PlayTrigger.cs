using UnityEngine;
using System.Collections;

public class PlayTrigger : MonoBehaviour {

	[FMODUnity.EventRef]
	public string music = "event:/Tune";
	FMOD.Studio.EventInstance musicEvent;

	// Use this for initialization
	void Start ()
	{
		musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			FMOD.Studio.PLAYBACK_STATE play_state;
			musicEvent.getPlaybackState(out play_state);
			if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING)
			{
				//musicEvent.start();
			}
		}
	}
}

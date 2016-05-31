using UnityEngine;
using System.Collections;

public class StopTrigger : MonoBehaviour {
	
	FMOD.Studio.EventInstance musicEvent;
	FMOD.Studio.ParameterInstance musicEndParam;

	// Use this for initialization
	void Start ()
	{
		musicEvent.getParameter("end", out musicEndParam);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			FMOD.Studio.PLAYBACK_STATE play_state;
			musicEvent.getPlaybackState(out play_state);
			if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
			{
				//musicEndParam.setValue(1);
			}
		}
	}
}

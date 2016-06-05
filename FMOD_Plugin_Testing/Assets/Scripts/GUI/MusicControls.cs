using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MusicControls : MonoBehaviour
{
	[FMODUnity.EventRef]
		public string music = "event:/Music/Music";
		public FMOD.Studio.EventInstance musicEvent;
		private FMOD.Studio.PLAYBACK_STATE play_state;
		private FMOD.Studio.ParameterInstance intensity;
		private FMOD.Studio.ParameterInstance panner;

	private float intensityValue;
	private float pannerValue;

	void Start()
	{
		musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);
		musicEvent.getParameter("Intensity", out intensity);
		intensity.getValue(out intensityValue);
		musicEvent.getParameter("Panner", out panner);
		intensity.getValue(out pannerValue);
	}

	void Update()
	{
		if (musicEvent.isValid())
			musicEvent.getPlaybackState(out play_state);
	}

	public void PlayMusic()
	{
		if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING)
		{
			musicEvent.start();
			intensity.setValue(0);
			intensityValue = 0;
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void StopMusic()
	{
		if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
		{
			musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void KillMusic()
	{
		if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
		{
			musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			EventSystem.current.SetSelectedGameObject(null);
		}
	}
	
	public void NextStep()
	{
		if (intensityValue < 0.9f)
		{
			intensity.setValue(intensityValue + 0.2f);
		}

		intensity.getValue(out intensityValue);
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void PrevStep()
	{
		if (intensityValue > 0.1f)
		{
			intensity.setValue(intensityValue - 0.2f);
		}

		intensity.getValue(out intensityValue);
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void SetPanner(Slider slider)
	{
		pannerValue = slider.value;
		panner.setValue(pannerValue);
	}

}

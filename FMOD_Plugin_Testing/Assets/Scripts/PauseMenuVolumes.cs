using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuVolumes : MonoBehaviour
{
	public Slider musicSlider;
	public Slider sfxSlider;
	public Slider masterSlider;


	string musicBusPath = "bus:/Music";
	FMOD.Studio.Bus musicBus;
	FMOD.ChannelGroup musicChannelGroup;
	float musicVolume;

	string sfxBusPath = "bus:/SFX";
	FMOD.Studio.Bus sfxBus;
	FMOD.ChannelGroup sfxChannelGroup;
	float sfxVolume;

	string masterBusPath = "bus:/";
	FMOD.Studio.Bus masterBus;
	FMOD.ChannelGroup masterChannelGroup;
	float masterVolume;

	FMOD.RESULT result;

	FMOD.Studio.System system;
	FMOD.Studio.VCA musicVCA;

	void Start ()
	{
		//result = FMOD.Studio.System.create(out system);
	}
	
	void OnEnable()
	{
		system = FMODUnity.RuntimeManager.StudioSystem;

		musicBus = FMODUnity.RuntimeManager.GetBus(musicBusPath);
		musicBus.getFaderLevel(out musicVolume);
		musicSlider.value = musicVolume;

		sfxBus = FMODUnity.RuntimeManager.GetBus(sfxBusPath);
		sfxBus.getFaderLevel(out sfxVolume);
		sfxSlider.value = sfxVolume;
		
		masterBus = FMODUnity.RuntimeManager.GetBus(masterBusPath);
		masterBus.getFaderLevel(out masterVolume);
		masterSlider.value = masterVolume;
	}

	void Update ()
	{
	
	}

	public void SetMusicVolume(Slider slider)
	{
		musicBus.setFaderLevel(musicVolume);
	}

	public void SetSFXVolume(Slider slider)
	{
		sfxBus.setFaderLevel(sfxVolume);
	}

	public void SetMasterVolume(Slider slider)
	{
		masterBus.setFaderLevel(masterVolume);
	}
}

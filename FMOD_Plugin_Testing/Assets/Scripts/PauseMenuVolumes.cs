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
	float musicVolume;

	string sfxBusPath = "bus:/SFX";
	FMOD.Studio.Bus sfxBus;
	float sfxVolume;

	string masterBusPath = "bus:/";
	FMOD.Studio.Bus masterBus;
	float masterVolume;

	FMOD.RESULT result;

	FMOD.Studio.System system;

	void Start ()
	{

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
		system.update();
	}

	public void SetMusicVolume(Slider slider)
	{
		result = musicBus.setFaderLevel(musicVolume);
		system.update();
	}

	public void SetSFXVolume(Slider slider)
	{
		result = sfxBus.setFaderLevel(sfxVolume);
		system.update();
	}

	public void SetMasterVolume(Slider slider)
	{
		result = masterBus.setFaderLevel(masterVolume);
		system.update();
	}
}

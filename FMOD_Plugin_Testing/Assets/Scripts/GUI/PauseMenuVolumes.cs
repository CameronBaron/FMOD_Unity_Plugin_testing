using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuVolumes : MonoBehaviour
{
	public Slider musicSlider;					// GUI sliders
	public Slider sfxSlider;					
	public Slider masterSlider;

	string musicBusPath = "bus:/Music";			// Path to bus (groups in FMOD Studio under Routing)
	FMOD.Studio.Bus musicBus;					// Reference to bus
	float musicVolume;							// float to hold volume level

	string sfxBusPath = "bus:/SFX";
	FMOD.Studio.Bus sfxBus;
	float sfxVolume;

	string masterBusPath = "bus:/";
	FMOD.Studio.Bus masterBus;
	float masterVolume;

	FMOD.RESULT result;							// Use result checking while testing		

	void Start ()
	{
		// Get the corresponding bus
		musicBus = FMODUnity.RuntimeManager.GetBus(musicBusPath);
		// Fader level is the sounds output volume level
		musicBus.getFaderLevel(out musicVolume);	
		// Assign initial music level to slider
		musicSlider.value = musicVolume;

		sfxBus = FMODUnity.RuntimeManager.GetBus(sfxBusPath);
		sfxBus.getFaderLevel(out sfxVolume);
		sfxSlider.value = sfxVolume;

		masterBus = FMODUnity.RuntimeManager.GetBus(masterBusPath);
		masterBus.getFaderLevel(out masterVolume);
		masterSlider.value = masterVolume;
	}

	// Function called from UI Slider OnValueChanged()
	public void SetMusicVolume(Slider slider)
	{
		// Set bus fader level to the slider.value
		result = musicBus.setFaderLevel(musicSlider.value);
	}

	public void SetSFXVolume(Slider slider)
	{
		result = sfxBus.setFaderLevel(sfxSlider.value);
	}

	public void SetMasterVolume(Slider slider)
	{
		result = masterBus.setFaderLevel(masterSlider.value);
	}
}

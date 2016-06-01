using UnityEngine;
using System.Collections.Generic;

public class SoundLookup : MonoBehaviour
{
	public static readonly SoundLookup _instance = new SoundLookup();

	public List<FMOD.Studio.EventInstance> events;
	public List<FMOD.Studio.EventDescription> eventDescriptions;
	public List<FMOD.ChannelGroup> channelGroups;
	public List<FMOD.DSP> dsps;

	FMOD.DSP_METERING_INFO dspOutput;

	public FMOD.Studio.System system;
	
	//public static Dictionary<string, FMOD.Studio.EventInstance> soundTable;
	
	SoundLookup() {}


	void Start ()
	{
		// Make FMOD Vars
		events = new List<FMOD.Studio.EventInstance>();
		eventDescriptions = new List<FMOD.Studio.EventDescription>();
		channelGroups = new List<FMOD.ChannelGroup>();
		dsps = new List<FMOD.DSP>();

		// Get reference to main FMOD system.
		system = FMODUnity.RuntimeManager.StudioSystem;

		FMOD.ChannelGroup group;
		FMOD.Studio.EventInstance event1;
		FMOD.Studio.EventDescription event1Desc;


	}
	
}

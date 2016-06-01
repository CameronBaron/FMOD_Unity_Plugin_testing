using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeTextDisplay : MonoBehaviour
{
	public Slider slider;
	Text text;

	void Start ()
	{
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = (slider.value * 100).ToString("F0");
	}
}

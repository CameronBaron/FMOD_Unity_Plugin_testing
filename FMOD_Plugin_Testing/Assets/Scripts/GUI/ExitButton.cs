using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

	
	void OnClick()
	{
		Debug.Log("exit pressed");
		Application.Quit();
	}
}

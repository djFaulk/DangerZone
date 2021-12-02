using UnityEngine;
using System.Collections;

public class SoundMang : MonoBehaviour {

	public UISlider _Volumeslider;
	public AudioSource audioS;

	void Awake()
	{
		audioS = GetComponent<AudioSource> ();
	
	}
	
	void Update () {
		//audioS.volume = _Volumeslider.value;
	}
}

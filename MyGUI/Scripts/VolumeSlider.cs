using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour
{

	public Transform vol;
	public static float val1;

	void Awake ()
	{
		val1 = AudioListener.volume;
	}

	private AudioSource myAudio;

	void Start ()
	{
		UISlider levolume = GetComponent<UISlider> ();
		myAudio = GetComponent<AudioSource> ();
//       levolume.initialValue = val1;
//       levolume.UpdateSlider();
		levolume.sliderValue = val1;
//		levolume
	}
	
	void AudioSwitch ()
	{  
		if (!myAudio.playOnAwake) {  
			myAudio.Play ();  
			myAudio.playOnAwake = true;  
		} else {  
			myAudio.Stop ();  
			myAudio.playOnAwake = false;  
		}  
	}
	
	void OnSliderChange (float val)
	{
		AudioListener.volume = val;
	}
}

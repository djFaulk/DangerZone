using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

		public GameObject chargingPart;
		public GameObject laserPart;
		public GameObject light;
		public AudioClip charging;
		public AudioClip firing;
		public GameObject laserCol;
		public float speed;
		public bool laserActive;
        private Light lig;
		private Vector3 pointA;
		private Vector3 pointB;
	
	
		IEnumerator Start ()
		{
            lig = light.GetComponent<Light>();
		
				while (true) {
						yield return StartCoroutine (ChargeUp ());
						yield return StartCoroutine (ChargeSound (true));
						yield return new WaitForSeconds (3.0f);
						yield return StartCoroutine (ChargeSound (false));
						yield return StartCoroutine (FireSound (true));
						yield return StartCoroutine (FireLaser ());
						yield return new WaitForSeconds (1.5f);
						yield return StartCoroutine (FireSound (false));
						laserActive = false;
						yield return new WaitForSeconds (3.0f);
                        lig.intensity = 0;
						
						
				}
		}
		IEnumerator ChargeSound (bool toPlay)
		{
				if (toPlay) {
						gameObject.GetComponent<AudioSource> ().clip = charging;
						gameObject.GetComponent<AudioSource> ().Play ();
				} else {
						gameObject.GetComponent<AudioSource> ().Stop ();
				}
				yield return 0;
		}	

		IEnumerator FireSound (bool toPlay)
		{
				if (toPlay) {
						gameObject.GetComponent<AudioSource> ().clip = firing;
						gameObject.GetComponent<AudioSource> ().Play ();
				} else {
						gameObject.GetComponent<AudioSource> ().Stop ();
				}
				yield return 0;
		}
	
		IEnumerator FireLaser ()
		{
				Debug.Log ("here");

				float i = 0.0f;
				float rate = 1.0f / 1.0f;
				while (i < 1.0f) {
						i += Time.deltaTime * rate;
						laserPart.GetComponent<ParticleSystem> ().Play ();
						
						laserActive = true;
						yield return 0; 
				}
		}

		IEnumerator ChargeUp ()
		{
				float i = 0.0f;
				float rate = 1.0f / 1.0f;
				while (i < 1.0f) {
						i += Time.deltaTime * rate;
						chargingPart.GetComponent<ParticleSystem> ().Play ();
						yield return 0; 
				}
		}

		void Update ()
		{
            if (laserActive)
            {
                lig.intensity = Mathf.Lerp(lig.intensity, 30f, Time.deltaTime * 5f);
            }
            else if (!laserActive)
            {
                lig.intensity = Mathf.Lerp(lig.intensity, 0f, Time.deltaTime * 5f);
            }
				laserCol.GetComponent<Collider>().enabled = laserActive;
		}
}

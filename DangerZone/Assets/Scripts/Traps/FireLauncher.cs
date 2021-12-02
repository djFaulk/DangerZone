using UnityEngine;
using System.Collections;

public class FireLauncher : MonoBehaviour
{

		public GameObject projectile;
		//public GameObject pointBGO;
	
		public float speed;
		public bool rotate = false;
	
		private Vector3 pointA;
		private Vector3 pointB;
	
	
		IEnumerator Start ()
		{
				//pointA = pointAGO.transform.position;
				//pointB = pointBGO.transform.position;
		
				//transform.position = pointA;
		
				while (true) {
						yield return StartCoroutine (FireObject (speed));
						yield return new WaitForSeconds (Random.Range (0.5f, 2.0f));
						//yield return StartCoroutine (MoveObject (transform, pointB, pointA, speed));
				}
		}
	
		IEnumerator FireObject (float pSpeed)
		{
				GameObject fireball = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
				fireball.transform.GetComponent<Rigidbody>().AddForce (Vector3.up * pSpeed, ForceMode.Impulse);
				fireball.transform.parent = this.transform;
				Destroy (fireball, 1f);
				yield return 0;

		}
	

}

using UnityEngine;
using System.Collections;

public class WaterDetector : MonoBehaviour
{

		void OnTriggerEnter (Collider Hit)
		{
				if (Hit.GetComponent<Rigidbody>() != null && Hit.tag == "Player") {
						transform.parent.GetComponent<Water> ().Splash (transform.position.x, Hit.GetComponent<Rigidbody>().velocity.y * Hit.GetComponent<Rigidbody>().mass / 40f);
				}
		}

		

}

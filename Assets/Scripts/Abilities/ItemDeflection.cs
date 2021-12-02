using UnityEngine;
using System.Collections;

public class ItemDeflection : MonoBehaviour
{

		public float deflection = 1000.0f;
		public GameObject shield;

		// Use this for initialization
		void Start ()
		{

        

		}
	
		// Update is called once per frame
		void Update ()
		{
		
				if (transform.parent.GetComponent<Invisibility> ().invisible == true) {
						//	collider.enabled = true;
			
				}


		}

		
}

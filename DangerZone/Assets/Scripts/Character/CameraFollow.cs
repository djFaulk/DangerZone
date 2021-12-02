using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
		public GameObject player;
    
		// Use this for initialization
		void Start ()
		{
	
		}
    
		void Update ()
		{
				var newX = player.transform.position.x;
				//  var newZ = player.transform.position.z;
				var y = transform.position.y;
				var z = transform.position.z;
				var chaseSpeed = .3f;

				transform.position = transform.position +
						(new Vector3 (newX, y, z) - transform.position) * chaseSpeed;
		}
}
 
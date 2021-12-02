using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
		[SerializeField] private Transform player;
		[SerializeField] private Vector3 pos;
		[SerializeField] private float smoothSpeed = 10f;
		private Vector3 velocity = new Vector3(0,0,0);
    
		// Use this for initialization
		void Start ()
		{
		}
    
		void FixedUpdate ()
		{
			Debug.Log("Camera upadted to: " + transform.position);
			Vector3 desiredPosition = player.transform.position + pos;
			//If we want the camera to smoothly follow flag
			//Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
			transform.position = desiredPosition;
		}
}
 
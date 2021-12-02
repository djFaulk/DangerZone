using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LinearSaw : MonoBehaviour
{
		public GameObject pointAGO;
		public GameObject pointBGO;

		public float speed;
		public bool rotate = false;
		
		private Vector3 pointA;
		private Vector3 pointB;


		IEnumerator Start ()
		{
				pointA = pointAGO.transform.position;
				pointB = pointBGO.transform.position;

				transform.position = pointA;

				while (true) {
						yield return StartCoroutine (MoveObject (transform, pointA, pointB, speed));
						yield return StartCoroutine (MoveObject (transform, pointB, pointA, speed));
				}
		}
	
		IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
		{
				float i = 0.0f;
				float rate = 1.0f / time;
				while (i < 1.0f) {
						i += Time.deltaTime * rate;
						thisTransform.position = Vector3.Lerp (startPos, endPos, i);
						yield return 0; 
				}
		}

		void Update ()
		{
				if (rotate) {

						transform.Rotate (Vector3.back * Time.deltaTime * 900f);
				}
		}
}

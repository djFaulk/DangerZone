using UnityEngine;
using System.Collections;

public class ElementMove : MonoBehaviour
{
		float moveAmount = 4f;
		bool isSeen = false;
		public GameObject start;
		public GameObject finish;
		Vector3 finalPos = Vector3.zero;
		Vector3 original = Vector3.zero;

		// Use this for initialization
		void Start ()
		{
				original = start.transform.position;
				finalPos = finish.transform.position;
				transform.position = original;
		}

		void Update ()
		{
				// UpdateParaPosition();
				if (!isSeen) {
						Return ();
				} else {
						Move ();
				}
        

		}

		public void Move ()
		{
				UpdateParaPosition ();
				transform.position = Vector3.Lerp (transform.position, finalPos, Time.deltaTime * 10f);
        
		}

		public void Return ()
		{
				UpdateParaPosition ();
				transform.position = Vector3.Lerp (transform.position, original, Mathf.SmoothStep (0.0f, 1.0f, Time.deltaTime * 5f));
     
		}

		public void CameraNotActive ()
		{
				isSeen = false;
		}

		public void CameraActive ()
		{
				isSeen = true;
		}

		void UpdateParaPosition ()
		{
				Vector3 paraPos = transform.root.GetComponent<ParallaxLayer> ().GetParaPosition ();
				transform.position += new Vector3 (paraPos.x, 0, 0);
				start.transform.position += new Vector3 (paraPos.x, 0, 0);
				finish.transform.position += new Vector3 (paraPos.x, 0, 0);
				original = start.transform.position;
				finalPos = finish.transform.position;
		}
}

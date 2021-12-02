using UnityEngine;
using System.Collections;

public class PlatformTether : MonoBehaviour
{
		LineRenderer rope;
		GameObject startPos;
		public GameObject endPos;

		// Use this for initialization
		void Start ()
		{
				startPos = this.gameObject;
				rope = GetComponent<LineRenderer> ();
				rope.SetPosition (0, startPos.transform.position);
				rope.SetPosition (1, endPos.transform.position);
				


		}
	
		// Update is called once per frame
		void Update ()
		{
	
				UpdateRopeEndPos (startPos.transform.position, endPos.transform.position);
		}

		void UpdateRopeEndPos (Vector3 begin, Vector3 end)
		{
				rope.SetPosition (0, begin);
				rope.SetPosition (1, end);
		}
}

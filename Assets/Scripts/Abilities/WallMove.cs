using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour 
{

    GameObject player;

    public float timer = 3.0f;

    public float amountToRaiseBy = 0.8f;

    public float finalPosition = 3.5f;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

	// Use this for initialization
	void Start () 
    {

        StartCoroutine("MoveWall");

	}
	
	// Update is called once per frame
	void Update () 
    {

        timer -= Time.deltaTime;

         //Debug.Log(timer);

        if (timer <= 0)
        {

            Destroy(gameObject);

            timer = 3.0f;

        }
	
	}

    IEnumerator MoveWall()
    {

        while (transform.localScale.y < finalPosition)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + amountToRaiseBy, transform.localScale.z);

            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(0.0f, amountToRaiseBy / 2, 0.0f) + transform.position, Time.deltaTime * 10.0f);

           // yield return null;
            yield return new WaitForSeconds(0.01f);

        }

        yield return null;

    }

}

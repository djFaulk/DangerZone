using UnityEngine;
using System.Collections;

public class LeftCharDisplay : MonoBehaviour {



	public Sprite char1;
	public Sprite char2;
	public Sprite char3;
	public Sprite char4;

	public int p1_SelectedChar;

	public UISprite LeftCharPic;


	// Use this for initialization
	// void Start () {
	
	// 	LeftCharPic = GetComponent<UISprite>(); 

	// 	p1_SelectedChar = CharSelection.p1Char;

	// 	if(p1_SelectedChar == 1)
	// 		LeftCharPic.sprite = char1;
	// 	if (p1_SelectedChar == 2)
	// 		LeftCharPic.sprite = char2;
	// 	if (p1_SelectedChar == 3)
	// 		LeftCharPic.sprite2D = char3;
	// 	if (p1_SelectedChar == 4)
	// 		LeftCharPic.sprite2D = char4;
	// }
	
	// // Update is called once per frame
	// void Update () 
	// {

	// 	if (Input.GetKeyDown (KeyCode.Space))
	// 	{
	// 		LeftCharPic.sprite2D = char2;
	// 	}
	// 	if (Input.GetKeyDown (KeyCode.A)) 
	// 	{
	// 		LeftCharPic.sprite2D = char1;
	// 	}
	// 	if (Input.GetKeyDown (KeyCode.S)) 
	// 	{
	// 		LeftCharPic.sprite2D = char3;
	// 	}
	// 	if (Input.GetKeyDown (KeyCode.D)) 
	// 	{
	// 		LeftCharPic.sprite2D = char4;
	// 	}
	
	// }
}

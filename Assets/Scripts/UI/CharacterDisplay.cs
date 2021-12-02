using UnityEngine;
using System.Collections;

public class CharacterDisplay : MonoBehaviour
{

		//public static CharacterDisplay Instance;



		/*void Awake()
	{
		Instance = this;
	}*/

		public int p1_SelectedChar;
		public int p2_SelectedChar;

		public Sprite char1;
		public Sprite char2;
		public Sprite char3;
		public Sprite char4;
		public Sprite char1A;
		public Sprite char2A;
		public Sprite char3A;
		public Sprite char4A;
	
//	public Sprite item0;
//	public Sprite item1;
//	public Sprite item2;
//	public Sprite item3;
//	public Sprite item4;


		public GameObject leftCharDisplayPort;
		public GameObject rightCharDisplayPort;
		public GameObject leftItemDisplayPort;
		public GameObject rightItemDisplayPort;
		public GameObject timer;

		UILabel LeftCharPic;
		UILabel RightCharPic;
		//UI2DSprite LeftItemPic;
		//UI2DSprite RightItemPic;
		UILabel timerObj;


//	GameObject p1_CurrentItem;
//	GameObject p2_CurrentItem;
//	public UI2DSprite p1_Item;
//	public UI2DSprite p2_Item;


//	void AbilityOnCoolDown(int inputInt)
//	{
//		float coolDownInSeconds = 25f;
//		float timeStamp = Time.time + coolDownInSeconds;
//
//		if(inputInt == 11)
//		{
//			// grays out pic
//			TweenPosition.Begin(leftItemDisplayPort, 1, 0);
//
//			//wait some seconds...
//			if(timeStamp <= Time.time)
//			//ability comes back on un-grey pic
//				TweenPosition.Begin(leftItemDisplayPort, 1, 1);
//		}
//	}

		void Start ()
		{

				LeftCharPic = leftCharDisplayPort.GetComponent<UILabel> ();
				RightCharPic = rightCharDisplayPort.GetComponent<UILabel> (); 
				//LeftItemPic = leftItemDisplayPort.GetComponent<UI2DSprite> ();
				//RightItemPic = rightItemDisplayPort.GetComponent<UI2DSprite> ();
				timerObj = timer.GetComponent<UILabel> ();
				p1_SelectedChar = CharSelection.p1Char;
				p2_SelectedChar = CharSelection.p2Char;

				

//		p1_Item = p1_CurrentItem.GetComponent<UI2DSprite>();
//		p2_Item = p2_CurrentItem.GetComponent<UI2DSprite>();
		
			
		}
	

		void Update ()
		{
				if (Global.Instance.player1Item != null) {
						//LeftItemPic.sprite2D = Global.Instance.player1Item;
				} else {
						//LeftItemPic.sprite2D = null;

				}
				if (Global.Instance.player2Item != null) {
						//RightItemPic.sprite2D = Global.Instance.player2Item;
				} else {
						//RightItemPic.sprite2D = null;
			
				}
                timerObj.text = (Global.Instance.time).ToString() + " seconds";
				RightCharPic.text = Global.Instance.player2Score.ToString ();
				LeftCharPic.text = Global.Instance.player1Score.ToString ();

				
		
		}
}

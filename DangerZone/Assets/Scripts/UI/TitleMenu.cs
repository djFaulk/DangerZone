using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour
{
		public GameObject PlayButton;
		public GameObject Options;
		public GameObject Exit;
		public GameObject gameWindow;
		public GameObject TitleText;
		public GameObject CharacterMenu;
        public GameObject AboutMenu;
		bool P1C1Selected = false;
		bool P1C2Selected = false;
		bool P2C1Selected = false;
		bool P2C2Selected = false;
		public GameObject P1B1;
		public GameObject P1B2;
		public GameObject P2B1;
		public GameObject P2B2;

		public GameObject ninja;
		public GameObject wallGuy;
		
		public Vector3 endPos = new Vector3 (-2000f, -112f, 0);
		public Vector3 startPos = new Vector3 (80f, -110.7363f, 0);

	#region Tween Objects
		public TweenPosition gameTween;
		public TweenPosition titleTween;
		public TweenAlpha characterAlphaTween;
        public TweenAlpha aboutTween;
	
	#endregion
		
		void Start ()
		{
            aboutTween = AboutMenu.GetComponent<TweenAlpha>();
				characterAlphaTween = CharacterMenu.GetComponent<TweenAlpha> ();
				gameTween = gameWindow.GetComponent<TweenPosition> ();
				titleTween = TitleText.GetComponent<TweenPosition> ();
				
				titleTween.eventReceiver = gameObject;
	
		}

		public void OnPlayButtonClicked ()
		{
				
				characterAlphaTween.from = 0;
				characterAlphaTween.to = 1;
				//titleTween.Play ();
                titleTween.callWhenFinished = "FadeInCharacterSelect";
				//gameTween.Play ();
				//P1B1.GetComponent<UIKeyNavigation> ().startsSelected = true;

			
		}
		
		public void OnBackSelected ()
		{
				characterAlphaTween.from = 1;
				characterAlphaTween.to = 0;
				//characterAlphaTween.Play ();
				//gameTween.PlayReverse ();
				//titleTween.PlayReverse ();

		}
		
		public void OnExitSelected ()
		{
				Application.Quit ();
		}

        public void OnAboutSelected()
        {
            aboutTween.from = 0;
            aboutTween.to = 1;
            //titleTween.Play();
            titleTween.callWhenFinished = "FadeInAbout";
            //gameTween.Play();
       
        }

        void FadeInAbout()
        {
            //aboutTween.Play();
        }

        public void OnBackSelectedAbout()
        {
            aboutTween.from = 1;
            aboutTween.to = 0;
            //aboutTween.Play();
            //gameTween.PlayReverse();
            //titleTween.PlayReverse();
        }
		
		public void P1NinjaSelected ()
		{
				
				
				P1C1Selected = !P1C1Selected;
				if (P1C1Selected) {
						P1C2Selected = false;
						//P1B2.GetComponent<UIButton> ().SetState (UIButtonColor.State.Normal, true);
						Global.Instance.SetPlayerOneGO (ninja);

				} else if (!P1C1Selected) {
						Global.Instance.SetPlayerOneGO (null);
				}
				//	P1B1.GetComponent<UIButtonColor> ().UpdateColor (true);
		}
		public void P1WallSelected ()
		{
				P1C2Selected = !P1C2Selected;
				if (P1C2Selected) {
						P1C1Selected = false;
						//P1B1.GetComponent<UIButton> ().SetState (UIButtonColor.State.Normal, true);
						Global.Instance.SetPlayerOneGO (wallGuy);
			
				} else if (!P1C2Selected) {
						Global.Instance.SetPlayerOneGO (null);
				}
		}
		public void P2NinjaSelected ()
		{
				P2C1Selected = !P2C1Selected;
				if (P2C1Selected) {
						P2C2Selected = false;
						//P2B2.GetComponent<UIButton> ().SetState (UIButtonColor.State.Normal, true);
						Global.Instance.SetPlayerTwoGO (ninja);
			
				} else if (!P2C1Selected) {
						Global.Instance.SetPlayerTwoGO (null);
				}
		}
		public void P2WallSelected ()
		{
				P2C2Selected = !P2C2Selected;
				if (P2C2Selected) {
						P2C1Selected = false;
						//P2B1.GetComponent<UIButton> ().SetState (UIButtonColor.State.Normal, true);
						Global.Instance.SetPlayerTwoGO (wallGuy);
			
				} else if (!P2C2Selected) {
						Global.Instance.SetPlayerTwoGO (null);
				}
		}
	
		public void OnPlayBegin ()
		{
				if (Global.Instance.GetPlayerOneGO () != null && Global.Instance.GetPlayerTwoGO () != null)
						Application.LoadLevel ("test");
		}

		void DisableScriptCharacter ()
		{
				characterAlphaTween.enabled = false;
		}
		
		void FadeInCharacterSelect ()
		{
		
				
				//characterAlphaTween.Play ();
		}
		
		void Update ()
		{
				if (P1C1Selected) {
						//P1B1.GetComponent<UIButton> ().SetState (UIButtonColor.State.Pressed, true);
				} 
				if (P1C2Selected) {
						//P1B2.GetComponent<UIButton> ().SetState (UIButtonColor.State.Pressed, true);
				} 
				if (P2C1Selected) {
						//P2B1.GetComponent<UIButton> ().SetState (UIButtonColor.State.Pressed, true);
				} 
				if (P2C2Selected) {
						//P2B2.GetComponent<UIButton> ().SetState (UIButtonColor.State.Pressed, true);
				} 
		
		}
}

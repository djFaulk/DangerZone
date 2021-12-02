using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelection : MonoBehaviour
{

		public static CharSelection InstanceS;
		void Awake ()
		{
				InstanceS = this;
		}
		public List<GameObject> characterPrefabs;
		public UIButton ninjaButton1;
		public UIButton wallmanButton1;



		public UIButton ninjaButton2;
		public UIButton wallmanButton2;



		public bool p1_ninja;
		public bool p1_wallman;
		public bool p1_gunman;
		public bool p1_gambler;

		public bool p2_ninja;
		public bool p2_wallman;
		public bool p2_gunman;
		public bool p2_gambler;

		public static int p1Char;
		public static int p2Char;

		public void buttonColorOnSelect ()
		{

				//P1 Buttons
				if (p1_ninja == true)
						ninjaButton1.defaultColor = Color.green;
				else
						//ninjaButton1.ResetDefaultColor ();

				if (p1_wallman == true)
						wallmanButton1.defaultColor = Color.green;
				else
						//wallmanButton1.ResetDefaultColor ();



				//P2 Buttons
				if (p2_ninja == true)
						ninjaButton2.defaultColor = Color.green;
				else
						//ninjaButton2.ResetDefaultColor ();
			
				if (p2_wallman == true)
						wallmanButton2.defaultColor = Color.green;
				//else
						//wallmanButton2.ResetDefaultColor ();
			
				//setCharacter();
		}

		public void p1_ninjaSelcted ()
		{
				{
						p1_ninja = true;
						p1_wallman = false;
						p1_gunman = false;
						p1_gambler = false;
						Global.Instance.playerOneGameObject = characterPrefabs [0];

				}
				buttonColorOnSelect ();
				//	CharacterDisplay.Instance.characterDisplayPls (11);
		}
		public void p1_wallmanSelcted ()
		{
		
				{
						p1_ninja = false;
						p1_wallman = true;
						p1_gunman = false;
						p1_gambler = false;
						Global.Instance.playerOneGameObject = characterPrefabs [1];
				}
				buttonColorOnSelect ();
				//	CharacterDisplay.Instance.characterDisplayPls (12);
		}
		public void p1_gunmanSelcted ()
		{
		
				{
						p1_ninja = false;
						p1_wallman = false;
						p1_gunman = true;
						p1_gambler = false;
						Global.Instance.playerOneGameObject = characterPrefabs [2];
				}
				buttonColorOnSelect ();
				//	CharacterDisplay.Instance.characterDisplayPls (13);
		}
		

		public void p2_ninjaSelcted ()
		{
				{
						p2_ninja = true;
						p2_wallman = false;
						p2_gunman = false;
						p2_gambler = false;
						Global.Instance.playerTwoGameObject = characterPrefabs [0];
				}
				buttonColorOnSelect ();
				//	CharacterDisplay.Instance.characterDisplayPls (21);
		}
		public void p2_wallmanSelcted ()
		{
		
				{
						p2_ninja = false;
						p2_wallman = true;
						p2_gunman = false;
						p2_gambler = false;
						Global.Instance.playerTwoGameObject = characterPrefabs [1];
				}
				buttonColorOnSelect ();
				//		CharacterDisplay.Instance.characterDisplayPls (22);
		}
		public void p2_gunmanSelcted ()
		{
		
				{
						p2_ninja = false;
						p2_wallman = false;
						p2_gunman = true;
						p2_gambler = false;
						Global.Instance.playerTwoGameObject = characterPrefabs [2];
				}
				buttonColorOnSelect ();
				//		CharacterDisplay.Instance.characterDisplayPls (23);
		}
		

		
}

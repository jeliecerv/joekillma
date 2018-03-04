using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
	int pos_new;
	string name_new;
	int score_new;

	string names_playerpref;
	string[] names = new string[10];
	string name_default = "AAA|BBB|CCC|DDD|EEE|FFF|GGG|HHH|III|JJJ";
	//string[] names_default = new string[] {"AAA","BBB","CCC","DDD","EEE","FFF","GGG","HHH","III","JJJ"};

	string scores_playerpref;
	string[] scores = new string[10];
	string score_default = "100|90|80|70|60|50|40|30|20|10";
	//string[] score_default  = new string[] {"100","90","80","70","60","50","40","30","20","10"};

	public Text name1Text;
	public InputField name1InputField;
	public Text score1Text;

	public Text name2Text;
	public InputField name2InputField;
	public Text score2Text;

	public Text name3Text;
	public InputField name3InputField;
	public Text score3Text;

	public Text name4Text;
	public InputField name4InputField;
	public Text score4Text;

	public Text name5Text;
	public InputField name5InputField;
	public Text score5Text;

	public Text name6Text;
	public InputField name6InputField;
	public Text score6Text;

	public Text name7Text;
	public InputField name7InputField;
	public Text score7Text;

	public Text name8Text;
	public InputField name8InputField;
	public Text score8Text;

	public Text name9Text;
	public InputField name9InputField;
	public Text score9Text;
	
	public Text name10Text;
	public InputField name10InputField;
	public Text score10Text;

	public Button restBtn;
	public Button backBtn;

	// Use this for initialization
	void Start ()
	{
		restBtn.gameObject.SetActive (false);
		backBtn.gameObject.SetActive (false);

		//PlayerPrefs.GetString(
		name_new = "";
		score_new = Score.score;

		//Obtengo los score guardados.
		getTopScoreList ();

		//Seteo la pantalla Top Score.
		SetTopScoreList ();

		//Valido y habilito si alguien puede meter su score y lo grabo.
		SetNewScoreInTopScoreList ();

	}

	// Update is called once per frame
	void Update ()
	{
			
		if (Input.GetKeyDown (KeyCode.Return)) {

			switch (pos_new) {
			case 0:
				Debug.Log ("Case 1st");
				name_new = name1InputField.text;
				break;
			case 1:
				Debug.Log ("Case 2nd");
				name_new = name2InputField.text;
				break;
			case 2:
				Debug.Log ("Case 3rd");
				name_new = name3InputField.text;
				break;
			case 3:
				Debug.Log ("Case 4th");
				name_new = name4InputField.text;
				break;
			case 4:
				Debug.Log ("Case 5th");
				name_new = name5InputField.text;
				break;
			case 5:
				Debug.Log ("Case 6th");
				name_new = name6InputField.text;
				break;
			case 6:
				Debug.Log ("Case 7th");
				name_new = name7InputField.text;
				break;
			case 7:
				Debug.Log ("Case 8th");
				name_new = name8InputField.text;
				break;
			case 8:
				Debug.Log ("Case 9th");
				name_new = name9InputField.text;
				break;
			case 9:
				Debug.Log ("Case 10th");
				name_new = name10InputField.text;
				break;
			default:
				Debug.Log ("Default case");
				break;
			}

			if (pos_new < 10) {
				names [pos_new] = name_new;
				SetTopScoreList ();
				SaveTopScoreList ();
				pos_new = 10;
			}
		
		}

		if (pos_new == 10) {
			restBtn.gameObject.SetActive (true);
			backBtn.gameObject.SetActive (true);				
		}
	}


	void getTopScoreList ()
	{
	
		names_playerpref = PlayerPrefs.GetString ("NamesTopScore", name_default);
		scores_playerpref = PlayerPrefs.GetString ("ScoresTopScore", score_default);

		names = names_playerpref.Split ("|" [0]);
		scores = scores_playerpref.Split ("|" [0]);
	}


	void SetTopScoreList ()
	{
		name1Text.text = names [0];
		name1InputField.gameObject.SetActive (false);
		score1Text.text = scores [0];

		name2Text.text = names [1];
		name2InputField.gameObject.SetActive (false);
		score2Text.text = scores [1];

		name3Text.text = names [2];
		name3InputField.gameObject.SetActive (false);
		score3Text.text = scores [2];

		name4Text.text = names [3];
		name4InputField.gameObject.SetActive (false);
		score4Text.text = scores [3];

		name5Text.text = names [4];
		name5InputField.gameObject.SetActive (false);
		score5Text.text = scores [4];

		name6Text.text = names [5];
		name6InputField.gameObject.SetActive (false);
		score6Text.text = scores [5];

		name7Text.text = names [6];
		name7InputField.gameObject.SetActive (false);
		score7Text.text = scores [6];

		name8Text.text = names [7];
		name8InputField.gameObject.SetActive (false);
		score8Text.text = scores [7];

		name9Text.text = names [8];
		name9InputField.gameObject.SetActive (false);
		score9Text.text = scores [8];

		name10Text.text = names [9];
		name10InputField.gameObject.SetActive (false);
		score10Text.text = scores [9];

	}

	void SetNewScoreInTopScoreList ()
	{
		pos_new = 10;
		string[] temp_names = new string[10];
		string[] temp_scores = new string[10];

		for (int i = 0; i < 10; i++) {
			int top_score = int.Parse (scores [i]);
			if (score_new > top_score) {
				pos_new = i;
				break;				
			}
		}
		Debug.Log (pos_new);

		if (pos_new < 10) {
			temp_names = names;
			temp_scores = scores;

			if (pos_new != 9) {
				for (int i = 9; i > pos_new; i--) {
					names [i] = temp_names [i - 1];
					scores [i] = temp_scores [i - 1];
				}
			}

			name_new = "";
			names [pos_new] = name_new;
			scores [pos_new] = score_new.ToString ();

			SetTopScoreList ();

			switch (pos_new) {
			case 0:
				Debug.Log ("Case 1st");
				name1InputField.gameObject.SetActive (true);
				//score2Text.text = scores[pos_new];
				name1InputField.ActivateInputField ();
				break;
			case 1:
				Debug.Log ("Case 2nd");
				name2InputField.gameObject.SetActive (true);
				//score2Text.text = scores [pos_new];
				name2InputField.ActivateInputField ();
				break;
			case 2:
				Debug.Log ("Case 3rd");
				name3InputField.gameObject.SetActive (true);
				//score3Text.text = scores [pos_new];
				name3InputField.ActivateInputField ();
				break;
			case 3:
				Debug.Log ("Case 4th");
				name4InputField.gameObject.SetActive (true);
				//score4Text.text = scores [pos_new];
				name4InputField.ActivateInputField ();
				break;
			case 4:
				Debug.Log ("Case 5th");
				name5InputField.gameObject.SetActive (true);
				//score5Text.text = scores [pos_new];
				name5InputField.ActivateInputField ();
				break;
			case 5:
				Debug.Log ("Case 6th");
				name6InputField.gameObject.SetActive (true);
				//score6Text.text = scores [pos_new];
				name6InputField.ActivateInputField ();
				break;
			case 6:
				Debug.Log ("Case 7th");
				name7InputField.gameObject.SetActive (true);
				//score7Text.text = scores [pos_new];
				name7InputField.ActivateInputField ();
				break;
			case 7:
				Debug.Log ("Case 8th");
				name8InputField.gameObject.SetActive (true);
				//score8Text.text = scores [pos_new];
				name8InputField.ActivateInputField ();
				break;
			case 8:
				Debug.Log ("Case 9th");
				name9InputField.gameObject.SetActive (true);
				//score9Text.text = scores [pos_new];
				name9InputField.ActivateInputField ();
				break;
			case 9:
				Debug.Log ("Case 10th");
				name10InputField.gameObject.SetActive (true);
				//score10Text.text = scores [pos_new];
				name10InputField.ActivateInputField ();
				break;
			default:
				Debug.Log ("Default case");
				break;
			}
		}		
	}

	void SaveTopScoreList () {

		string temp_names = "";
		string temp_scores = "";

		for (int i = 0; i < 10; i++) {

			if (i != 10 - 1) {

				temp_names += names [i].ToString () + "|";
				temp_scores += scores [i].ToString () + "|";

			} else {

				temp_names += names [i].ToString ();
				temp_scores += scores [i].ToString ();
			}
		}

		PlayerPrefs.SetString ("NamesTopScore", temp_names);
		PlayerPrefs.SetString ("ScoresTopScore", temp_scores);

	}

	public void ResetTopScoreList () {
		
		names = name_default.Split ("|" [0]);
		scores = score_default.Split ("|" [0]);

		SetTopScoreList ();

		SaveTopScoreList ();

	}
}

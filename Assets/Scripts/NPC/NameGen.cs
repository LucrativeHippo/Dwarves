using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGen : MonoBehaviour {
	public static char[] seperate = new char[]{'\n'};

	private string[] female_first;
	private string[] male_first;

	void Awake(){
		male_first = Resources.Load("popular-male-first").ToString().Split(seperate);
		female_first = Resources.Load("popular-female-first").ToString().Split(seperate);

		dwarf_female_prefix = DwarfStringToArr(Resources.Load("Dwarf-female-prefix").ToString());
		dwarf_female_suffix = DwarfStringToArr(Resources.Load("Dwarf-female-suffix").ToString());
	}

	public string getMale(){
		return male_first[0];
	}
	public string getFemale(){
		//return female_first[i];
		int i = Random.Range(0,dwarf_female_prefix.Length-1);
		int j = Random.Range(0,dwarf_female_suffix.Length-1);
		return dwarf_female_prefix[i] + dwarf_female_suffix[j];
	}
	
	private string[] DwarfStringToArr(string s){
		Queue<string> arr = new Queue<string>();

		char[] cArr = s.ToCharArray();

		bool inWord = false;
		string word = "";
		for(int i=0;i<cArr.Length;i++){
			switch(cArr[i]){
				case '[':
					//start list
					break;
				case ']':
					// end list
					break;
				case ' ':
					// ignore
					break;
				case '\r':
					// ignore
					break;
				case '\n':
					// ignore
					break;
				case '"':
					inWord = !inWord;
					break;
				case ',':
					if(inWord)
						throw new UnityException("Comma found in word at position: "+i);
					else
						arr.Enqueue(word);
					word = "";
					break;
				default:
					word += cArr[i].ToString();
					break;

			}
		}


		// string []toArr = new string[arr.Count];
		// int j=0;
		// foreach(string n in arr){
		// 	toArr[j] = n;
		// 	j++;
		// }
		return arr.ToArray();
	}

	private string[] dwarf_male_prefix;
	private string[] dwarf_male_suffix;
	private string[] dwarf_female_prefix;
	private string[] dwarf_female_suffix;


	public static string create(bool male=false){
		if(male)
			return "LOLZ";
			//return MetaScript.GetNameGen().getMale();
		else
			return MetaScript.GetNameGen().getFemale();
	}
}

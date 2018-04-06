using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugDevPref{

public class BugDevPrefs : MonoBehaviour {
	Dictionary<string, string> data = new Dictionary<string, string>();

	public BugDevPrefs Instance;
	string androidPath;
	string pcPath;


	void Awake()
	{
		Instance = this;
	}


 	/// <summary>
	/// Retrieves the required object, takes two parameter. The object is saved in a playpref.
 	/// </summary>
 	/// needs two parameters 
	/// <param name="name">Type of the object that is to be retrieved ( use ref , as it is a reference type) .</param>
	/// <param name="obj">The name of the object that is to be retrieved</param>
 	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public void RetriveObject<T> (string name, ref T obj)
	{
		T readData;
		readData= JsonMapper.ToObject<T> (PlayerPrefs.GetString(name));
		obj = readData;
	
	}
	/// <summary>
	/// Saves the object to a json string and saves it in a playpref
	/// </summary>
	/// <param name="Name">Name of the object be saved.</param>
	/// <param name="obj">The object that is to be saved .</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public void SaveObject<T>( string Name , T obj)
	{

		JsonData writeData;
		writeData = JsonMapper.ToJson (obj);

		//save in file 
//		data.Add (Name, writeData.ToString ());
//		StringBuilder sb = new StringBuilder ();
//		JsonWriter writer = new JsonWriter (sb);
//		writer.WriteObjectStart ();
//		foreach(var item in data)
//		{
//			writer.WritePropertyName (item.Key);
//			writer.Write (item.Value);
//		}
//		writer.WriteObjectEnd ();
//		Debug.Log (sb);
//		File.AppendAllText (Application.dataPath + "/Resources/Objects.json" ,sb.ToString());

		// save in playerpref
		PlayerPrefs.SetString(Name,writeData.ToString());


	}
	void Start () 
	{
	ExampleClass Enemy = new ExampleClass ("henchmen", 2000, 5000, true);
	//ExampleClass Enemy2 = new ExampleClass ("boss", 44000, 45000, true);
		SaveObject ("myenemy",Enemy);
	//	data.Clear ();
	//	SaveObject ("Aliza",Enemy2);
		ExampleClass tems = new ExampleClass();
		RetriveObject <ExampleClass>("myenemy", ref tems);
		Debug.Log ("dkjfhkdhfkh    ====    " + tems.health);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



public class ExampleClass 
{
	public string name;
	public	int score;
	public int health;
	public bool isAlive;

	public ExampleClass(string _name,int _score, int _health,bool _isAlicve)
	{
		this.name = _name;
		this.score = _score;
		this.health = _health;
		this.isAlive = _isAlicve;
				
	}

	public ExampleClass(){
		
	}
	}
}
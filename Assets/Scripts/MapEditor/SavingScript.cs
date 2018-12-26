using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SavingScript : MonoBehaviour {

	public GameObject Grid;
	GridScript gridScript;
	public string filePath;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		if(filePath==""){
			filePath = Application.dataPath+"/grid.sav"; 
		}
		gridScript = Grid.GetComponent<GridScript>();
	}

	public void saveGrid(){
		//FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
		StreamWriter sw = File.CreateText(filePath);
		List <Panel> panelList = gridScript.panelList;
		foreach (Panel p in panelList){
			sw.WriteLine(p.x+"/"+p.y+"/"+p.c+";");
		}
		sw.WriteLine("\\POIs:\\");
		foreach(POI p in gridScript.pois){
			sw.WriteLine(p._name+"/"+p._pos.x+"/"+p._pos.y+"/"+p._desc+"/"+p._color.r+"/"+p._color.g+"/"+p._color.b+"/"+string.Join(";",p._tags.ToArray()));
		}
		sw.Flush();
		//fs.Flush();
	}

	public void loadGrid(){
        filePath = GameObject.Find("pathSave").GetComponent<InputField>().text;
		FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
		StreamReader sr = new StreamReader(fs);
		List<string> pList = new List<string>();
		string s = sr.ReadLine();
		while(!sr.EndOfStream && s!="\\POIs:\\"){
			pList.Add(s);
			s = sr.ReadLine();
		}
		gridScript.loadPanelList(pList);
		if(s=="\\POIs:\\"){
			s = sr.ReadLine();
			do{
				string[] parts = s.Split("/".ToCharArray());
				Debug.Log(s);
				gridScript.addPOI(parts);
				s = sr.ReadLine();
			}while(!sr.EndOfStream);
		}
		sr.Close();
	}
}

using UnityEngine;
using System.Collections.Generic;

public class PilaPalletMng : MonoBehaviour 
{
	public List<GameObject> BolasasEnCamion = new List<GameObject>();
	public int CantAct = 0;
	
	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < BolasasEnCamion.Count; i++)
		{
			BolasasEnCamion[i].GetComponent<Renderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public void Sacar()
	{
		BolasasEnCamion[CantAct-1].GetComponent<Renderer>().enabled = false;
		CantAct--;
	}
	
	public void Agregar()
	{
		CantAct++;
		BolasasEnCamion[CantAct-1].GetComponent<Renderer>().enabled = true;
		
	}
}

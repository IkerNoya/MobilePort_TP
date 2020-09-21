using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MngPts : MonoBehaviour 
{
	Rect R = new Rect();
	
	public float TiempEmpAnims = 2.5f;
	float Tempo = 0;
	DataManager data = DataManager.Get();
	public Vector2[] DineroPos;
	public Vector2 DineroEsc;
	public GUISkin GS_Dinero;
	
	public Vector2 GanadorPos;
	public Vector2 GanadorEsc;
	public Texture2D[] Ganadores;
	public GUISkin GS_Ganador;
	
	public GameObject Fondo;
	
	public float TiempEspReiniciar = 10;
	
	
	public float TiempParpadeo = 0.7f;
	float TempoParpadeo = 0;
	bool PrimerImaParp = true;
	
	public bool ActivadoAnims = false;
	
	Visualizacion Viz = new Visualizacion();
	
	//---------------------------------//
	
	// Use this for initialization

	// Update is called once per frame
	void Update () 
	{
		StartCoroutine(ReturnToMenu());
		
		
		if(ActivadoAnims)
		{
			TempoParpadeo += Time.deltaTime;
			
			if(TempoParpadeo >= TiempParpadeo)
			{
				TempoParpadeo = 0;
				
				if(PrimerImaParp)
					PrimerImaParp = false;
				else
				{
					TempoParpadeo += 0.1f;
					PrimerImaParp = true;
				}
			}
		}
		
		
		
		if(!ActivadoAnims)
		{
			Tempo += Time.deltaTime;
			if(Tempo >= TiempEmpAnims)
			{
				Tempo = 0;
				ActivadoAnims = true;
			}
		}
		
		
	}
	
	void OnGUI()
	{	
		GUI.skin = null;
	}
	
	IEnumerator ReturnToMenu()
	{
		yield return new WaitForSeconds(5.0f);
		SceneManager.LoadScene("Menu");
		yield return null;
	}
	
	public void DesaparecerGUI()
	{
		ActivadoAnims = false;
		Tempo = -100;
	}
}

using UnityEngine;
using System.Collections;

public class Frenado : MonoBehaviour 
{
	public float VelEntrada = 0;
	public string TagDeposito = "Deposito";
	
	ControlDireccion KInput;
	
	
	float DagMax = 15f;
	float DagIni = 1f;
	int Contador = 0;
	int CantMensajes = 10;
	float TiempFrenado = 0.5f;
	float timer = 0f;
	
	Vector3 Destino;
	
	public bool Frenando = false;
	bool ReduciendoVel = false;
	
	//-----------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		//RestaurarVel();
		Frenar();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void FixedUpdate ()
	{
		if(Frenando)
		{
			timer += Time.deltaTime;
			if(timer >= (TiempFrenado / CantMensajes) * Contador)
			{
				Contador++;
			}
			if(timer >= TiempFrenado)
			{
				//termino de frenar, que haga lo que quiera
			}
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == TagDeposito)
		{
			Deposito2 dep = other.GetComponent<Deposito2>();
			if(dep.Vacio)
			{	
				if(this.GetComponent<Player>().ConBolasas())
				{
					dep.Entrar(this.GetComponent<PlayerScript>());
					Destino = other.transform.position;
					transform.forward = Destino - transform.position;
					Frenar();
				}				
			}
		}
	}
	
	//-----------------------------------------------------------//
	
	public void Frenar()
	{
		GetComponent<ControlDireccion>().enabled = false;
		gameObject.SendMessage("SetAcel", 0f);
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		Frenando = true;
		
		timer = 0;
		Contador = 0;
	}
	
	public void RestaurarVel()
	{
		GetComponent<ControlDireccion>().enabled = true;
		gameObject.SendMessage("SetAcel", 1f);
		Frenando = false;
		timer = 0;
		Contador = 0;
	}
}

using UnityEngine;
using System.Collections.Generic;

public class ManejoPallets : MonoBehaviour 
{
	protected List<Pallet> Pallets = new List<Pallet>();
	public ControladorDeDescarga Controlador;
	protected int Contador = 0;
	
	public virtual bool Recibir(Pallet pallet)
	{
		Pallets.Add(pallet);
		pallet.Pasaje();
		return true;
	}
	
	public bool Tenencia()
	{
		
		if(Pallets.Count != 0)
			return true;
		else
			return false;
		
		/*
		if(Pallets.Count > Contador)
			return true;
		else
			return false;
			*/
	}
	
	public virtual void Dar(ManejoPallets receptor)
	{
		//es el encargado de decidir si le da o no la bolsa
	}
}

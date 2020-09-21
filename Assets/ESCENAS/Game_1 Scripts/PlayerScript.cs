using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int money = 0;
    public Bolsa[] Bags;
    int currentBags = 0;
    public ControladorDeDescarga cd;
    public int IdPlayer = 0;
    public delegate void CamChange();
    public static event CamChange changeCams;

    public enum State
    {
        Driving, Delivering
    }
    public enum playerSelect
    {
        player1, player2
    }
    public State state;
    public playerSelect player;
    void Start()
    {
        for (int i = 0; i < Bags.Length; i++)
            Bags[i] = null;
    }

    void Update()
    {
        
    }
    public void CambiarADescarga()
    {
        state = PlayerScript.State.Delivering;
        changeCams();
    }
    public void CambiarAConduccion()
    {
        state = PlayerScript.State.Driving;
        changeCams();
    }

    public bool AgregarBolsa(Bolsa bag)
    {
        if (currentBags + 1 <= Bags.Length)
        {
            Bags[currentBags] = bag;
            currentBags++;
            money += (int)bag.Monto;
            bag.Desaparecer();
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeOutBags()
    {
        for (int i = 0; i < Bags.Length; i++)
        {
            if (Bags[i] != null)
            {
                Bags[i] = null;
                return;
            }
        }
    }
    public bool HasBags()
    {
        for (int i = 0; i < Bags.Length; i++)
        {
            if (Bags[i] != null)
            {
                return true;
            }
        }
        return false;
    }
    public void EmptyInventory()
    {
        for (int i = 0; i < Bags.Length; i++)
            Bags[i] = null;

        currentBags = 0;
    }
    public void SetContrDesc(ControladorDeDescarga contr)
    {
        cd = contr;
    }

    public ControladorDeDescarga GetContrDesc()
    {
        return cd;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deposito"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            CambiarADescarga();
            Deposito2 dep = other.GetComponent<Deposito2>();
            cd.Activar(dep);
        }
    }
}

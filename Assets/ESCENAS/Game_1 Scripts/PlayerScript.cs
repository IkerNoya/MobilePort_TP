using System;
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
    public static event Action<PlayerScript> AddMoney1;
    public static event Action<PlayerScript> AddMoney2;
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

    public bool AgregarBolsa(Bolsa bag)
    {
        if (currentBags + 1 <= Bags.Length)
        {
            Bags[currentBags] = bag;
            currentBags++;
            money += (int)bag.Monto;
            if(player == playerSelect.player1)
                AddMoney1(this);
            if (player == playerSelect.player2)
                AddMoney2(this);
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
                currentBags--;
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
        if (HasBags())
        {
            if (other.gameObject.CompareTag("Deposito"))
            {
                Deposito2 dep = GetComponent<Deposito2>();
                cd.Activar(dep);
            }
        }
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{

    public int currentMana;
    public int maxMana;
    public int howManyMana;
    public ManaBar manaBar;




    private void Start()
    {
        currentMana = maxMana;
      
        manaBar.SetMaxMana(maxMana);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddMana();

        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            RemoveMana();

        }

    }
    private void AddMana()
    {
       currentMana = currentMana + howManyMana;
        manaBar.SetMana(currentMana);
    }

    private void RemoveMana()
    {
       currentMana = currentMana - howManyMana;
      
        manaBar.SetMana(currentMana);
    }
}

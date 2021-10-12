using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

   public CharacterStat_SO  characterDefinition;
   public CharacterInventory characterInventory;
   public GameObject characterWeaponSlot;

  #region Constructor
   public CharacterStats() 
   {
     characterInventory = CharacterInventory.instance;
   }

  #endregion

  #region Inizialization
   private void Start() 
   {
       if (!characterDefinition.SetManually)
       {
           characterDefinition.maxHealth = 100;
           characterDefinition.currentHealth = 50;

           characterDefinition.maxMana = 25;
           characterDefinition.currentHealth = 10;

           characterDefinition.maxWealth= 500;
           characterDefinition.currentWealth= 0;

           characterDefinition.baseResistance =0;
           characterDefinition.currentResistance =0;
           
           characterDefinition.maxEmcumbrance = 50f;
           characterDefinition.currentEmcumbrance = 0;

           characterDefinition.charExperience =0;
           characterDefinition.charlevel = 1;
       }
   }
  #endregion

  #region Updates
  
   void Update() 
   {
     /*if (Input.GetMouseButtonDown(2))
     {
       characterDefinition.saveCharacterData();
     } */

   }
  
  #endregion

  #region stat Increasers
   public void ApplyHealth(int healthAmount) 
   {
       characterDefinition.ApplyHealth(healthAmount);
   }

   public void ApplyMana(int ManaAmount)
   {
       characterDefinition.ApplyMana(ManaAmount);
   }

   public void GiveWealth(int wealthAmount) 
   {
     characterDefinition.GiveWealth(wealthAmount);
   }

  #endregion

   #region Stat Reducers
    public void TakeDamage(int amount)
    {
      characterDefinition.TakeDamage(amount);
    }
    
    public void TakeMana(int manamount)
    {
      characterDefinition.TakeMana(manamount);
    }

   #endregion    

   #region Weapon and Armor Change
    public void ChangeWeapon(ItemPickUp weaponPickUp)
    {
      if (!characterDefinition.UnEquipWeapon(weaponPickUp,characterInventory,characterWeaponSlot))
      {
        characterDefinition.EquipWeapon(weaponPickUp,characterInventory,characterWeaponSlot);
      }
    }

    public void ChangeArmor(ItemPickUp armorPickUp)
    {
       if (!characterDefinition.UnEquipArmor(armorPickUp,characterInventory))
       {
           characterDefinition.EquipArmor(armorPickUp,characterInventory);
       }
    }

   #endregion

   #region Reporters
   public int GetHealth()
   {
       return characterDefinition.currentHealth;
   }

   public ItemPickUp GetCurrentWeapon()
   {
       return characterDefinition.weapon;
   }

   #endregion
}

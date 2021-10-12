using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="NewStas",menuName ="Character/Stas",order =1)]
public class CharacterStat_SO : ScriptableObject
{

  [System.Serializable]
  public class CharLevelUp{
     public int maxHealth;
     public int maxMana;
     public int maxWealth;
     public int baseDamage;
     public float baseResistance;
     public float maxEmcumbrance;

  }

   #region Fields
     public bool SetManually = false;
     public bool saveDateOnClose = false;
     public ItemPickUp weapon {get;private set;}
     public ItemPickUp headArmor {get; private set;}
     public ItemPickUp chestArmor {get; private set;}
     public ItemPickUp handArmor {get; private set;}
     public ItemPickUp legArmor {get; private set;}
     public ItemPickUp footArmor {get; private set;}
     public ItemPickUp misc1 {get; private set;}
     public ItemPickUp misc2 {get; private set;}
     public int maxHealth = 0;
     public int currentHealth = 0;
     
     public int maxMana = 0;
     public int currentMana = 0;
     public int maxWealth = 0;
     public int currentWealth = 0;
     public int baseDamage = 0;
     public int currentDamage =0;
     public float baseResistance = 0f;
     public float currentResistance = 0f;
     public float maxEmcumbrance =0f;
     public float currentEmcumbrance =0f;
     public int charExperience =0;
     public int charlevel = 0;
     public CharLevelUp[] charLevelUps;

   #endregion

   #region Stat Increasers

   public void ApplyHealth(int healthAmount)
   {
     if((currentHealth+healthAmount)>maxHealth)
     {
         currentHealth = maxHealth;
     }
     else {
         currentHealth += healthAmount;
     }
   }

   public void ApplyMana(int ManaAmount)
   {
     if ((currentMana+ManaAmount)>maxMana)
     {
          currentMana = maxMana;
     }
     else 
     {
        currentMana += ManaAmount;
     }
   }

   public void GiveWealth(int wealthAmount)
   {
       if((currentWealth+wealthAmount)>maxWealth)
        {
            currentWealth = maxWealth;
        }
        else 
        {
            currentWealth += wealthAmount;
        }
   }

   public void EquipWeapon(ItemPickUp weaponPickUp,CharacterInventory characterInventory, GameObject weaponSlot)
   {
     weapon = weaponPickUp;
     currentDamage = baseDamage+weapon.itemDefinition.itemAmount;
   }

   public void EquipArmor(ItemPickUp armorPickUp,CharacterInventory charInventory)
   {
     switch(armorPickUp.itemDefinition.itemArmorSubType)
     {
         case itemArmorSubType.Head:
         headArmor= armorPickUp;
         currentResistance+=armorPickUp.itemDefinition.itemAmount;
         break;

           case itemArmorSubType.Chest:
           chestArmor = armorPickUp;
           currentResistance+=armorPickUp.itemDefinition.itemAmount;
           break;

           case itemArmorSubType.Hands:
           handArmor = armorPickUp;
           currentResistance+=armorPickUp.itemDefinition.itemAmount;
           break;

           case itemArmorSubType.Legs:
           legArmor = armorPickUp;
           currentResistance+=armorPickUp.itemDefinition.itemAmount;
           break;

           case itemArmorSubType.Boots:
           footArmor = armorPickUp;
           currentResistance+=armorPickUp.itemDefinition.itemAmount;
           break;
     }
     
   }

   #endregion

   #region Stat Reducers
    public void TakeDamage(int amount)
    {
      currentHealth-= amount;
      if (currentHealth<=0)
      {
        Death();
      }
    }

    public void TakeMana(int Amount)
    {
       currentMana-=Amount;
       if (currentMana<0)
       {
           currentMana=0;
       }
    }

    public bool UnEquipWeapon(ItemPickUp weaponPickUp,CharacterInventory charInventory,GameObject weaponSlot)
    {
      bool previousWeaponSame = false;

      if (weapon != null)
      {
        if (weapon== weaponPickUp)
        {
          previousWeaponSame = true;
        }
        DestroyObject(weaponSlot.transform.GetChild(0).gameObject);
        weapon = null;
        currentDamage=baseDamage;
      }

      return previousWeaponSame;
    }

    public bool UnEquipArmor(ItemPickUp ArmorPickUp,CharacterInventory charInventory ) 
    {
      bool previousArmorSame = false;

      switch(ArmorPickUp.itemDefinition.itemArmorSubType)
      {
        case itemArmorSubType.Head:
        if (headArmor != null)
        {
          if (headArmor == ArmorPickUp)
          {
            previousArmorSame = true;
          }
          currentResistance-= ArmorPickUp.itemDefinition.itemAmount;
          headArmor = null;
        }
        break;

        case itemArmorSubType.Chest:
        if (chestArmor != null)
        {
          if (chestArmor == ArmorPickUp)
          {
            previousArmorSame = true;
          }
          currentResistance-= ArmorPickUp.itemDefinition.itemAmount;
          chestArmor = null;
        }
        break;

        case itemArmorSubType.Hands:
        if (handArmor != null)
        {
          if (handArmor == ArmorPickUp)
          {
            previousArmorSame = true;
          }
          currentResistance-= ArmorPickUp.itemDefinition.itemAmount;
          handArmor = null;
        }
        break;

        case itemArmorSubType.Legs:
        if (legArmor != null)
        {
          if (legArmor == ArmorPickUp)
          {
            previousArmorSame = true;
          }
          currentResistance-= ArmorPickUp.itemDefinition.itemAmount;
          legArmor = null;
        }
        break;

        case itemArmorSubType.Boots:
        if (footArmor != null)
        {
          if (footArmor == ArmorPickUp)
          {
            previousArmorSame = true;
          }
          currentResistance-= ArmorPickUp.itemDefinition.itemAmount;
          footArmor = null;
        }
        break;

      }
       return previousArmorSame;
    }

   #endregion

   #region CharacterLevelUp and Death
    
    private void Death()
    {
      Debug.Log("You're Dead");
    }
    
    private void LevelUp()
    {
     charlevel +=1;

      maxHealth = charLevelUps[charlevel-1].maxHealth;
      maxMana = charLevelUps[charlevel-1].maxMana;
      maxWealth = charLevelUps[charlevel-1].maxWealth;
      baseDamage = charLevelUps[charlevel-1].baseDamage;
      baseResistance = charLevelUps[charlevel-1].baseResistance;
      maxEmcumbrance =  charLevelUps[charlevel-1].maxEmcumbrance;
    }
   #endregion

   #region saveCharacterData
   public void saveCharacterData()
   {
     //saveDateOnClose = true;
     //EditorUtility.SetDirty(this);
   }
   #endregion
}

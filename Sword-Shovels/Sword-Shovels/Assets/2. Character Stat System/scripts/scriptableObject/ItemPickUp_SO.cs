using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemTypeDefinition
{
   HEALTH,
   WEALTH,
   MANA,
   WEAPON,
   ARMOR,
   BUFF,
   EMPTY
}
public enum itemArmorSubType
{
   None,Head,Chest,Hands,Legs,Boots
}

[CreateAssetMenu(fileName ="new item", menuName ="SpawnableItem/New Pick-up",order =1 )]
public class ItemPickUp_SO : ScriptableObject
{
 public itemTypeDefinition itemType = itemTypeDefinition.HEALTH;
 public itemArmorSubType itemArmorSubType = itemArmorSubType.None;
 public int itemAmount=0;

}

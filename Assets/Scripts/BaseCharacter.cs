using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

	private string className;
	private string classDescription;
	//base stat
	private int vitality;		//hit point, resistance, regeneration
	private int wisdom;			//mana control, attack range, cast time, element affinity
	private int strength;		//attack power, hit point
	private int defense;		//resistance, reduce damage
	private int dexterity;		//attack speed, movement speed, accuracy, evasion
	private int intelligence;	//bonus exp, bonus gold, exp required, skill point, cool down
	private int luck;			//rate encounter, random item, critical hit

	private int maxHP;
	private int currentHP;
	private int maxMP;
	private int currentMP;
	private int currentSP;
	private int critRate;
	private int critDmg;
	private int currentEXP;
	private int expRequired;

	//element/attribute stat
	private int fireRes;
	private int fireAffi;
	private int waterRes;
	private int waterAffi;
	private int windRes;
	private int windAffi;
	private int thunderRes;
	private int thunderAffi;
	private int earthRes;
	private int earthAffi;
	private int holyRes;
	private int holyAffi;
	private int darkRes;
	private int darkAffi;
	private int physicalRes;

	public string ClassName{
		get{return className; }
		set {className = value; }
	}
	public string ClassDescription {
		get{return classDescription; }
		set {classDescription = value; }
	}

	public int Vitality{
		get{return vitality; }
		set {vitality = value; }
	}
	public int Wisdom{
		get{return wisdom; }
		set {wisdom = value; }
	}
	public int Strength{
		get{return strength; }
		set {strength = value; }
	}
	public int Defense{
		get{return defense; }
		set {defense = value; }
	}
	public int Dexterity{
		get{return dexterity; }
		set {dexterity = value; }
	}
	public int Intelligence{
		get{return intelligence; }
		set {intelligence = value; }
	}
	public int Luck{
		get{return luck; }
		set {luck = value; }
	}

	public int MaxHP{
		get{return maxHP; }
		set {maxHP = strength * vitality; }
	}
	public int CurrentHP{
		get{return currentHP; }
		set {currentHP = value; }
	}
	public int MaxMP{
		get{return maxMP; }
		set {maxMP = intelligence * wisdom; }
	}
	public int CurrentMP{
		get{return currentMP; }
		set {currentMP = value; }
	}
	public int CurrentSP{
		get{return currentSP; }
		set {currentSP = value; }
	}
	public int CritRate{
		get{return critRate; }
		set {critRate = luck; }
	}
	public int CritDmg{
		get{return critDmg; }
		set {critDmg = luck * strength; }
	}
	public int CurrentEXP{
		get{return currentEXP; }
		set {currentEXP = value; }
	}
	public int ExpRequired{
		get{return expRequired; }
		set {expRequired = value - intelligence; }
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour {

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

	public string ClassName{ get; set; }
	public string ClassDescription { get; set; }
	public int Vitality { get; set; }
	public int Wisdom { get; set; }
	public int Strength { get; set; }
	public int Defense { get; set; }
	public int Dexterity { get; set; }
	public int Intelligence { get; set; }
	public int Luck { get; set; }

	//max hitpoint value
	public int MaxHP{
		get{return maxHP; }
		set {maxHP = strength * vitality; }
	}
	public int CurrentHP { get; set; }
	//max mana point value, to use skill and magic
	public int MaxMP{
		get{return maxMP; }
		set {maxMP = intelligence * wisdom; }
	}
	public int CurrentMP { get; set; }
	//skill point, to get skill to level up
	public int CurrentSP { get; set; }
	//chance to get critical damage
	public int CritRate{
		get{return critRate; }
		set {critRate = luck; }
	}
	//critical damage, depend on luck 
	public int CritDmg{
		get{return critDmg; }
		set {critDmg = luck * strength; }
	}
	public int CurrentEXP{
		get{return currentEXP; }
		set {currentEXP = value; }
	}
	//exp point needed to level up
	public int ExpRequired{
		get{return expRequired; }
		set {expRequired = value - intelligence; }
	}

	// Use this for initialization
	public virtual void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}

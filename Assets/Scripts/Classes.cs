using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity{
	public float armor;
	public float health;
	public float maxHealth;
	public float contactDMG;
	public GameObject self;	

	void Die(){
		GameObject.Destroy(self);
	}


	public void TakeDamge(float damage){
		damage-=armor;
		if (damage<0){
			damage=0;
		}
		health-=damage;
		if(health<=0){
			Die();	
		}
	}
}

public class Player:Entity{
	public float maxFuel;
	public float fuelRegen; 
	public float fuel;
	public Transform[] bars;

	void StatToBar(Transform bar,float current,float max){
		bar.localScale = new Vector3(3.5f*current/max,.25f,1);
		bar.localPosition = new Vector3((bar.localScale.x-3.5f)/2,0,0);
	}
	
	public void UpdateBars(){
	    StatToBar(bars[0],health,maxHealth); 
        StatToBar(bars[1],fuel,maxFuel); 
	    bars[1].localPosition*=-1;
	}

	public void UpdateFuel(){
		Debug.Log(fuel);
		if(fuel<maxFuel){
			fuel+=fuelRegen*Time.deltaTime;
			if(fuel>maxFuel){
				fuel=maxFuel;
			}
			UpdateBars();
		}
	}
}

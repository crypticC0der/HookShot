using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
	public static Player Alf;
	public Transform[] bars;
	
    void Start()
    {
		Alf = new Player();
		Alf.maxHealth=50;
		Alf.fuelRegen=0.025F;
		Alf.maxFuel =0.5F;
		Alf.health=Alf.maxHealth;
		Alf.fuel=Alf.maxFuel;
		Alf.self=gameObject;
		Alf.armor=0;
		Alf.contactDMG=.5F;
		Alf.bars=bars;
		Alf.UpdateBars();
    }

    // Update is called once per frame
    void Update()
    {
		Alf.UpdateFuel();
	}
}

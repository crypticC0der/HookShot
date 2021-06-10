using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCode : MonoBehaviour
{
	Vector3 velocity;
	public Entity self;	
    // Start is called before the first frame update
    void Start()
    {
		velocity=new Vector3(0,0,0);
		self = new Entity();
		self.armor=0;
		self.maxHealth=100;
		self.contactDMG=0;
		self.self=gameObject;
		self.health=self.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		if (Random.value<4*Time.deltaTime){
			CalcVelocity();
		}
		transform.position+=velocity*Time.deltaTime;
    }
	
	void CalcVelocity(){
		velocity = PlayerControl.Alf.self.transform.position-transform.position;
		velocity = velocity.normalized*2f;
		float theata = -Mathf.Atan(velocity.x/velocity.y)*180F/Mathf.PI;
		if (velocity.y<0){theata+=180;}
		transform.eulerAngles = new Vector3(0,0,theata);
	}

	void OnCollisionEnter2D(Collision2D col){
		CalcVelocity();
		float dmg;
		switch (col.gameObject.tag){
			case "Player":
				dmg=PlayerControl.Alf.GetContactDMG();
				break;
			default:
				dmg=0;
				break;
		}
		self.TakeDamge(dmg);
		Debug.Log(dmg);
	}
}

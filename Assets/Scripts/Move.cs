using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	ParticleSystem boostparts;
	public TextMesh text;
	bool boosting=false;
	public float fuel=1F/2F;
	float mass =3;
	float lambda = 20;
	float net_len = 3;
	const float acceleration=16F/3F;
	public float max_speed;
	float res=4;
	public bool hooked=false;
	public Transform hook;
    // Start is called before the first frame update
    void Start()
    {
       vel = new Vector3(0,0,0); 
	   boostparts=gameObject.GetComponent<ParticleSystem>() as ParticleSystem;
    }

	Vector3 vel;
    // Update is called once per frame
    void Update()
    {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 acc = new Vector3(h,v,0)*(res + acceleration);
		if (vel.y>0){acc.y-=res;}
		if (vel.y<0){acc.y+=res;}
		if (vel.x>0){acc.x-=res;}
		if (vel.x<0){acc.x+=res;}
		
		if (hooked){
			Vector3 dist=hook.transform.position - transform.position;
			float length = Mathf.Sqrt(dist.x*dist.x + dist.y*dist.y);
			Vector3 force = dist.normalized * (lambda*length/net_len); 
			acc += force/mass;
			max_speed-= Time.deltaTime * (max_speed - 8)*4;
		}
		else
		{
			max_speed-= Time.deltaTime * (max_speed - 8F/3F)*2;
		}
		boosting = Input.GetAxis("Boost")>0 && fuel>0;
		float tmax_spd = max_speed;	
		ParticleSystem.EmissionModule em = boostparts.emission;
		em.enabled =boosting;
		if (boosting){
			fuel -=Time.deltaTime;
			max_speed*=2;	
		}
		vel += acc*Time.deltaTime;
		if (vel.x< 0.001F && vel.x>-0.001F){vel.x=0;}
		if (vel.y< 0.001F && vel.y>-0.001F){vel.y=0;}
		float spd = Mathf.Sqrt(vel.x*vel.x + vel.y*vel.y);
		if(spd>max_speed){vel*=max_speed/spd;}
		transform.position+=vel*Time.deltaTime;
		if (spd>0.2){
			float theata = -Mathf.Atan(vel.x/vel.y)*180F/Mathf.PI;
			if (vel.y<0){theata+=180;}
			transform.eulerAngles = new Vector3(0,0,theata);
		}
		max_speed=tmax_spd;
    }
}

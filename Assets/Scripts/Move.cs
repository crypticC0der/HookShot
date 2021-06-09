using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public float mass =1;
	public float lambda = 20;
	public float net_len = 2;
	const float acceleration=16/3;
	float max_speed;
	public float res;
	public bool hooked=false;
	public Transform hook;
    // Start is called before the first frame update
    void Start()
    {
       vel = new Vector3(0,0,0); 
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
			max_speed=32/3;
		}
		else
		{
			max_speed-= Time.deltaTime * (max_speed - 8/3)*2;
		}

		vel += acc*Time.deltaTime;
		if (vel.x< 0.001F && vel.x>-0.001F){vel.x=0;}
		if (vel.y< 0.001F && vel.y>-0.001F){vel.y=0;}
		float spd = Mathf.Sqrt(vel.x*vel.x + vel.y*vel.y);
		if(spd>max_speed){vel*=max_speed/spd;}
		transform.position+=vel*Time.deltaTime;
		if (spd>0.2){
			float theata = -Mathf.Atan(vel.x/vel.y)*180/Mathf.PI;
			if (vel.y<0){theata+=180;}
			transform.eulerAngles = new Vector3(0,0,theata);
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
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
		Vector3 acc = new Vector3(h,v,0)*(res + 16/6);
		if (vel.y>0){acc.y-=res;}
		if (vel.y<0){acc.y+=res;}
		if (vel.x>0){acc.x-=res;}
		if (vel.x<0){acc.x+=res;}
		vel += acc*Time.deltaTime;
		if (vel.x< 0.001F && vel.x>-0.001F){vel.x=0;}
		if (vel.y< 0.001F && vel.y>-0.001F){vel.y=0;}
		float spd = Mathf.Sqrt(vel.x*vel.x + vel.y*vel.y)*3;
		if(spd>16){vel*=16/spd;}
		transform.position+=vel*Time.deltaTime;
    }
}

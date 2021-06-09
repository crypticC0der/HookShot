using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    // Start is called before the first frame update
	public Camera cam;
	public GameObject hook;
	public GameObject trail;
	public bool shot=false;
	HookBehavior hb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButtonDown(1) && !shot){
			GameObject chook = Instantiate(hook) as GameObject;
			GameObject cshot = Instantiate(trail) as GameObject;
			chook.transform.position=transform.position;
			cshot.transform.position=transform.position;
			hb = chook.GetComponent<HookBehavior>() as HookBehavior;
			shot = true;
			hb.player = gameObject;
			Vector2 pos = Input.mousePosition;
			Vector3 v = cam.ScreenToWorldPoint(new Vector3(pos.x,pos.y,0));
			v-=transform.position;
			v.z=0;
			v=v.normalized;
			v*=32;
			shot =true;
			hb.trail = cshot;
			hb.vel=v;
		}
		else if(Input.GetMouseButtonDown(1)){
			hb.Suicide();
		}
    }
}

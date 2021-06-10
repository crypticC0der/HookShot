using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : MonoBehaviour
{
	public GameObject player;
	public Vector3 vel;
	public GameObject trail;
	bool shooting=true;
	SpriteRenderer sr;

	void OnCollisionEnter2D(Collision2D collision){
		Move mo = (player.GetComponent<Move>() as Move);
		mo.hook=transform;
		mo.hooked=true;
		vel = new Vector3(0,0,0);
		shooting = false;
	}

	public void Suicide(){
		(player.GetComponent<HookShot>() as HookShot).shot = false;
		Move mo = player.GetComponent<Move>() as Move;
		mo.hook=null;
		mo.hooked=false;
		GameObject.Destroy(trail);
		GameObject.Destroy(gameObject);
	}
    // Start is called before the first frame update
    void Start()
    {
		sr = trail.GetComponent<SpriteRenderer>() as SpriteRenderer; 
    }

    // Update is called once per frame
    void Update()
    {
		if(shooting){
			transform.position+=vel*Time.deltaTime;
		}
		trail.transform.position=(player.transform.position+transform.position)/2;
		Vector3 dist = transform.position - player.transform.position;
		float scalarDist=Mathf.Sqrt(dist.x*dist.x + dist.y*dist.y);
		if (shooting && scalarDist>50){
			Suicide();
		}
		sr.size = new Vector2(0.1F,scalarDist*2 -0.43F);
		float theata = -Mathf.Atan(dist.x/dist.y)*180/Mathf.PI;
		if (dist.y<0){theata+=180;}
		trail.transform.eulerAngles = new Vector3(0,0,theata);
		transform.eulerAngles = new Vector3(0,0,theata);
    }
}

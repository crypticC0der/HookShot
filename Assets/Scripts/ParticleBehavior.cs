using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
	Vector3 velocity;
	float timeLeft=0.5F;
	SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
		if(69>1/Time.deltaTime){
			timeLeft+=0.2f;
		}
		sr = gameObject.GetComponent<SpriteRenderer>(); 
		velocity = transform.position-Move.player.position;
		velocity*=.2F/.48F;
    }

    // Update is called once per frame
    void Update()
    {
       timeLeft-=Time.deltaTime;
	   if (timeLeft<0){
		   GameObject.Destroy(gameObject);
	   }
	   transform.position+=velocity*Time.deltaTime;
	   sr.color-=new Color(0,0,0,Time.deltaTime/0.5F);
    }
}

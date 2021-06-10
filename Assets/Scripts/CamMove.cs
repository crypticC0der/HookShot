using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    // Start is called before the first frame update
	public Transform player;
	public static Camera maincam;
	
    void Start()
    {
       maincam = gameObject.GetComponent<Camera>() as Camera; 
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = player.position;
		if (pos.x>4.25F){pos.x=4.25F;}
		if (pos.x<-4.25F){pos.x=-4.25F;}
		if (pos.y>2.175F){pos.y=2.175F;}
		if (pos.y<-2.175F){pos.y=-2.175F;}
		pos.z = -10;
		transform.position=pos;
    }
}

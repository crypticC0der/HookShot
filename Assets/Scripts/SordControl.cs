using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordControl : MonoBehaviour
{
	public GameObject sord;
	public GameObject particle;
	SpriteRenderer sordsr;
	const float part_interval=2F;
	const float max_rot=60;
	float angle_aim=max_rot;
	float rps=1280;
	int sign=1;
	float timer=.5F;
	float prevAngle;

	Vector3 posAtAngle(float angle){
		float rad = Mathf.PI*angle/180;
		return new Vector3(-Mathf.Sin(rad),Mathf.Cos(rad),0);
	}
	

    // Start is called before the first frame update
    void Start()
    {
		sordsr = sord.GetComponent<SpriteRenderer>() as SpriteRenderer; 
    }

    // Update is called once per frame
    void Update()
    {
		float angle=sord.transform.localEulerAngles.z;
		if (Input.GetMouseButtonDown(0)){
			rps*=-1;
			if (angle>max_rot&&angle<360-max_rot){
				angle=angle_aim;
			}
			angle_aim*=-1;
			sign*=-1;
	    }
		bool swing = angle <=max_rot|| angle>=360-max_rot; 
		sordsr.enabled = (swing||timer>0);
		timer-=Time.deltaTime;
		if (swing){
			sord.transform.localEulerAngles=new Vector3(0,0,angle+rps*Time.deltaTime);
			Vector3 pos=posAtAngle(angle);
			sord.transform.localPosition=pos*.38F;
			if (angle>180){
				angle=angle-360;
			}
			bool particled=false;
			while((prevAngle+part_interval<angle && sign==1) || (prevAngle+part_interval>angle&&sign==-1)){
				particled=true;
				GameObject cpart=Instantiate(particle) as GameObject;
				cpart.transform.position=transform.position+posAtAngle(prevAngle+transform.eulerAngles.z)*0.48F;
				prevAngle+=part_interval*sign;
			}
			if (particled){
				prevAngle=angle;
			}
			timer=.5F;
		}else if (angle>180){
			prevAngle=angle-360;
		}
    }
}


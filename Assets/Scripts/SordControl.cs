using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordControl : MonoBehaviour
{
	Vector3 lpartpos;
	SpriteRenderer sordsr;
	float angle_aim;
	int sign=1;
	float timer=0F;
	float prevAngle;

	Vector3 posAtAngle(float angle){
		float rad = Mathf.PI*angle/180;
		return new Vector3(-Mathf.Sin(rad),Mathf.Cos(rad),0);
	}
	

    // Start is called before the first frame update
    void Start()
    {
		angle_aim=PlayerControl.Alf.weapon.max_rot;
		lpartpos=new Vector3(0,0,0);
		sordsr = PlayerControl.Alf.weapon.self.GetComponent<SpriteRenderer>() as SpriteRenderer; 
    }

    // Update is called once per frame
    void Update()
    {
		float angle=PlayerControl.Alf.weapon.self.transform.localEulerAngles.z;
		if (Input.GetMouseButtonDown(0)){
			PlayerControl.Alf.weapon.radSpd*=-1;
			lpartpos=new Vector3(0,0,0);
			if (angle>PlayerControl.Alf.weapon.max_rot&&angle<360-PlayerControl.Alf.weapon.max_rot){
				angle=angle_aim;
			}
			prevAngle=angle;
			angle_aim*=-1;
			sign*=-1;
			

			while(1/Time.deltaTime<69&&((prevAngle+PlayerControl.Alf.weapon.part_interval<angle_aim && sign==1) || (prevAngle-PlayerControl.Alf.weapon.part_interval>angle_aim&&sign==-1))){
				GameObject cpart=Instantiate(PlayerControl.Alf.weapon.particle) as GameObject;
				cpart.transform.position=transform.position+posAtAngle(prevAngle+transform.eulerAngles.z)*0.48F;
				prevAngle+=PlayerControl.Alf.weapon.part_interval*sign;
			}


	    }
		bool swing = angle <=PlayerControl.Alf.weapon.max_rot|| angle>=360-PlayerControl.Alf.weapon.max_rot; 
		sordsr.enabled = (swing||timer>0);
		timer-=Time.deltaTime;
		if (swing){
			PlayerControl.Alf.weapon.self.transform.localEulerAngles=new Vector3(0,0,angle+PlayerControl.Alf.weapon.radSpd*Time.deltaTime);
			Vector3 pos=posAtAngle(angle);
			PlayerControl.Alf.weapon.self.transform.localPosition=pos*.38F;
			if (angle>180){
				angle=angle-360;
			}
			bool particled=false;
			if(1/Time.deltaTime >69){
				int particles = (int)(angle-prevAngle/PlayerControl.Alf.weapon.part_interval) * sign;
				int i =0;
				if (particles>0){
					GameObject epart = Instantiate(PlayerControl.Alf.weapon.particle) as GameObject;
					epart.transform.position=transform.position+posAtAngle(prevAngle+transform.eulerAngles.z)*0.48F;
					if (lpartpos.x==0 && lpartpos.y==0){
						lpartpos=epart.transform.position;
					}
					Vector3 change = epart.transform.position-lpartpos;
					while(i<particles){
						GameObject cpart=Instantiate(PlayerControl.Alf.weapon.particle) as GameObject;
						cpart.transform.position = lpartpos + change*((float)i/(float)particles);
						particled=true;
						i+=1;
					}
					lpartpos=epart.transform.position;
				}
			}
			while((prevAngle+PlayerControl.Alf.weapon.part_interval<angle && sign==1) || (prevAngle-PlayerControl.Alf.weapon.part_interval>angle&&sign==-1)){
				GameObject cpart=Instantiate(PlayerControl.Alf.weapon.particle) as GameObject;
				cpart.transform.position=transform.position+posAtAngle(prevAngle+transform.eulerAngles.z)*0.48F;
				prevAngle+=PlayerControl.Alf.weapon.part_interval*sign;
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


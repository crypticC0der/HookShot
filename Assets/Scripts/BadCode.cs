using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCode : MonoBehaviour
{
	public Entity self;	
    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}

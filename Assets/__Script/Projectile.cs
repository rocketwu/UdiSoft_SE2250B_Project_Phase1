using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private BoundsCheck bc;

    private void Awake()
    {
        bc = GetComponent<BoundsCheck>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!bc.isOnScreen)
        {
            Destroy(gameObject);
        }
	}
}

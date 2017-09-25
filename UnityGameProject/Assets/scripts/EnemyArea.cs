using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour {

    public GameObject player;

    bool shootPlayer = false;
    int count = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (shootPlayer)
        {
            count++;
            Debug.Log("shooting");
        }

        if (count > 5)
        {
            Destroy(player);
        }

	}
    
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            shootPlayer = true;
        }

        //if (trigger.tag == "Player")
        //{
        //    Debug.Log("Dying!");
        //}
    }
}

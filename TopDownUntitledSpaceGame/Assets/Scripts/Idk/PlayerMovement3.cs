using UnityEngine;
using System.Collections;

public class PlayerMovement3 : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;

	void Start () 
    {
	
	}
	
	void Update () 
    {

        Vector3 moveDirection = gameObject.transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * maxSpeed);
        }
    }
}

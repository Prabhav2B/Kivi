
using UnityEngine;

public class Forward_Movement : MonoBehaviour {

	public Rigidbody rb;
	public float forward_force = 1000F;

	void FixedUpdate () 
	{
		rb.AddForce(0, 0, forward_force * Time.deltaTime);
	}
}

using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public Rigidbody rb;
	public Transform player;

	public float forward_force = 1000F;
	public float sideways_force = 250F;
	public float threshold = -0.3F;

	void FixedUpdate () 
	{
		// Add Forward Force
		rb.AddForce(0, 0, forward_force * Time.deltaTime);
	
		if(Input.GetKey("d"))
		{
			rb.AddForce(sideways_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if(Input.GetKey("a"))
		{
			rb.AddForce(-sideways_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}
}

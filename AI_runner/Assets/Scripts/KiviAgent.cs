using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiviAgent : Agent {

	private const int MoveLeft = 0;
	private const int MoveRight = 1;
	private const int DoNothing = 2;

	//public int frequency = 25;

	public GameObject collectible_obj;

	//private int _lastAction;

	public Respawn res;
	public hud Hud;
	public GameObject agent;

	public float sideways_force = 50F;
	public float threshold_1 = -1F;

	public float freq ;
	public float target ;

	private int missStreak = 0;

	public Rigidbody rb;

	private int _lastAction;


	void Start()
	{

		freq = FindObjectOfType<KiviAcademy>().frequency; 
		target = FindObjectOfType<KiviAcademy>().thresh;
			_lastAction = 0;
	}


	public override List<float> CollectState()
	{
		return new List<float> { rb.position.x, collectible_obj.transform.position.x, collectible_obj.transform.position.z};
	}
		
	private void Move(float delta)
	{
		rb.AddForce(delta*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
	}

	public override void AgentStep(float[] action)
	{
		if ((int)action [0] == MoveLeft) {
			Move (-sideways_force);
		}
		else if ((int)action [0] == MoveRight) 
		{
			Move (sideways_force);
		} 
		else if((int)action [0] == DoNothing)
		{
			Move (0);	
		}
	
		if (collectible_obj.transform.position.z < rb.position.z-5) {

			reward = -(.6f * (++missStreak/10)) ;
			res.respawn (rb.position.z, freq);

		
		}


		if (rb.position.y < threshold_1) 
		{
			//Debug.Log (rb.position.y);
			//Debug.Log (threshold);

			res.respawn ();
			AgentFailed ();
		}
		else if (rb.position.z > target) 
		{
			//Debug.Log (rb.position.y);
			//Debug.Log (threshold);

			res.respawn ();
			AgentSuceed ();
		
		} else 
		{
			if (_lastAction == DoNothing)
				reward = -0.15f;

			_lastAction = (int) action[0];

			reward = .1f;
		}

	}

	private void AgentFailed()
	{
		Hud.deathIncrement();
		Hud.collection = 0;
		reward = -.3f;
		done = true;
	}

	private void AgentSuceed()
	{
		Hud.finishedIncrement ();
		Hud.collection = 0;

		missStreak = 0;

		reward = .6f;
		done = true;
	}

	public override void AgentReset()
	{
		agent.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		agent.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
		agent.transform.position = new Vector3 (0f, 0f, 0f);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{

			var randX = Random.Range (-4.5f, 4.5f);
			reward = .8f;
			
			missStreak = 0;

			other.gameObject.transform.position = new Vector3 (randX, 0f, other.gameObject.transform.position.z + freq);
			Hud.Collected();
		}
	}

}

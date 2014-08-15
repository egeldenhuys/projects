#pragma strict

var forwardForce : float = 2000.00;
var sideForce : float = 5.00;
var maxVelocity : float = 15.00;
var jumpForce : float = 1.00;
var gravityMultiplier : float = 200.0;
var explosion : ParticleSystem;
var MainCamera : Camera;
var dummyBall : GameObject;

function Start () {

}

function Update () {

// Jump
	if(Input.GetKey("space")){	
			//rigidbody.velocity = Vector3(rigidbody.velocity.x, 9.81 + 2, rigidbody.velocity.z);
			rigidbody.AddForce(Vector3(0, 9.81 * jumpForce, 0));
	}
	
	
	// Move left
	if(Input.GetKey("a"))
	{
		transform.localPosition.x += -sideForce * Time.deltaTime;
		
	}
	
	// Move right
	if(Input.GetKey("d"))
	{	
		transform.localPosition.x += sideForce * Time.deltaTime;
		
	}

}
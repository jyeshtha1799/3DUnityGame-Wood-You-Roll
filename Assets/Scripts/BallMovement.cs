using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {

	private string direction = "";
	private string directionLastFrame = "";

	[HideInInspector]
	public int onFloorTracker = 0;

	private bool fullSpeed = false;

	//speed variables
	private int floorSpeed = 100;
	private int airSpeed = 20;
	private float airSpeed_Diagonal = 5.858f;
	private float air_drag = 0.1f;
	private float floorDrag = 2.29f;
	private float delta = 50f;

	// camera variables
	private Vector3 cameraRelative_Right;
	private Vector3 cameraRelative_Up;
	private Vector3 cameraRelative_Down;
	private Vector3 cameraRelative_Up_Right;
	private Vector3 cameraRelative_Up_Left;

	// velocity and magnitude variables
	private Vector3 x_Vel;
	private Vector3 z_Vel;
	private float x_speed;
	private float z_speed;

	// movement axis
	private string Axis_Y = "Vertical";
	private string Axis_X = "Horizontal";

	private Rigidbody myBody;

	private Camera mainCamera;

	void Awake() {
		myBody = GetComponent<Rigidbody> ();
		mainCamera = Camera.main;
	}

	void Start () {
		
	}

	void Update () {
		UpdateCameraRelativePosition ();
		GetDirection ();
		FullSpeedController ();
		DragAdjustmentAndAirSpeed ();
		BallFellDown ();
	}

	void FixedUpdate() {
		MoveTheBall ();
	}

	void LateUpdate() {
		directionLastFrame = direction;
	}

	void GetDirection() {
		direction = "";

		if (Input.GetAxis (Axis_Y) > 0) {
			direction += "up";
		} else if (Input.GetAxis (Axis_Y) < 0) {
			direction += "down";
		}

		if (Input.GetAxis (Axis_X) > 0) {
			direction += "right";
		} else if (Input.GetAxis (Axis_X) < 0) {
			direction += "left";
		}

	}

	void MoveTheBall() {
		switch (direction) {
			
		case "upright":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * cameraRelative_Up_Right *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed  - 75f) * cameraRelative_Up_Right *
						Time.fixedDeltaTime * delta);
				}

			} else if (onFloorTracker == 0) {
				// in air
				if (z_Vel.normalized == cameraRelative_Up) {
					if (z_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * cameraRelative_Up *
						Time.fixedDeltaTime * delta);
					}
				} else {
					myBody.AddForce (10.6f * cameraRelative_Up * 
						Time.fixedDeltaTime * delta);
				}

				if (x_Vel.normalized == cameraRelative_Right) {
					if (x_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * cameraRelative_Right *
							Time.fixedDeltaTime * delta);
					}
				} else {
					myBody.AddForce (10.6f * cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				}

			}

			break;

		case "upleft":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * cameraRelative_Up_Left *
					Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * cameraRelative_Up_Left *
					Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(z_Vel.normalized == cameraRelative_Up) {
					if (z_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * cameraRelative_Up
							* Time.fixedDeltaTime * delta);
					} else {
						myBody.AddForce (10.6f * cameraRelative_Up 
							* Time.fixedDeltaTime * delta);
					}
				}

				if (x_Vel.normalized == -cameraRelative_Right) {
					if (x_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * -cameraRelative_Right *
						Time.fixedDeltaTime * delta);
					} 
				} else {
					myBody.AddForce (10.6f * -cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				}

			}

			break;

		case "downright":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * -cameraRelative_Up_Left *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * -cameraRelative_Up_Left *
						Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(z_Vel.normalized == -cameraRelative_Up) {
					if (z_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * -cameraRelative_Up
							* Time.fixedDeltaTime * delta);
					} else {
						myBody.AddForce (10.6f * -cameraRelative_Up 
							* Time.fixedDeltaTime * delta);
					}
				}

				if (x_Vel.normalized == cameraRelative_Right) {
					if (x_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * cameraRelative_Right *
							Time.fixedDeltaTime * delta);
					} 
				} else {
					myBody.AddForce (10.6f * cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				}

			}

			break;

		case "downleft":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * -cameraRelative_Up_Right *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * -cameraRelative_Up_Right *
						Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(z_Vel.normalized == -cameraRelative_Up) {
					if (z_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * -cameraRelative_Up
							* Time.fixedDeltaTime * delta);
					} else {
						myBody.AddForce (10.6f * -cameraRelative_Up 
							* Time.fixedDeltaTime * delta);
					}
				}

				if (x_Vel.normalized == -cameraRelative_Right) {
					if (x_speed < (airSpeed - airSpeed_Diagonal - 0.1f)) {
						myBody.AddForce (10.6f * -cameraRelative_Right *
							Time.fixedDeltaTime * delta);
					} 
				} else {
					myBody.AddForce (10.6f * -cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				}

			}

			break;

		case "up":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * cameraRelative_Up *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * cameraRelative_Up *
						Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(z_speed < airSpeed) {
					myBody.AddForce ((airSpeed * 0.75f) * cameraRelative_Up
						* Time.fixedDeltaTime * delta);
				}

				if (x_speed > 0.1f) {
					if (x_Vel.normalized == cameraRelative_Right) {
						myBody.AddForce ((airSpeed * 0.75f) * -cameraRelative_Right
							* Time.fixedDeltaTime * delta);	
					} else if (x_Vel.normalized == -cameraRelative_Right) {
						myBody.AddForce ((airSpeed * 0.75f) * cameraRelative_Right
							* Time.fixedDeltaTime * delta);
					}
				}

			}

			break;

		case "down":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * -cameraRelative_Up *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * -cameraRelative_Up *
						Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(z_speed < airSpeed) {
					myBody.AddForce ((airSpeed * 0.75f) * -cameraRelative_Up
						* Time.fixedDeltaTime * delta);
				}

				if (x_speed > 0.1f) {
					if (x_Vel.normalized == cameraRelative_Right) {
						myBody.AddForce ((airSpeed * 0.75f) * -cameraRelative_Right
							* Time.fixedDeltaTime * delta);	
					} else if (x_Vel.normalized == -cameraRelative_Right) {
						myBody.AddForce ((airSpeed * 0.75f) * cameraRelative_Right
							* Time.fixedDeltaTime * delta);
					}
				}

			}

			break;

		case "right":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(x_speed < airSpeed) {
					myBody.AddForce ((airSpeed * 0.75f) * cameraRelative_Right
						* Time.fixedDeltaTime * delta);
				}

				if (z_speed > 0.1f) {
					if (z_Vel.normalized == cameraRelative_Up) {
						myBody.AddForce ((airSpeed * 0.75f) * -cameraRelative_Up
							* Time.fixedDeltaTime * delta);	
					} else if (z_Vel.normalized == -cameraRelative_Up) {
						myBody.AddForce ((airSpeed * 0.75f) * cameraRelative_Up
							* Time.fixedDeltaTime * delta);
					}
				}

			}

			break;

		case "left":

			if (onFloorTracker > 0) {
				// on floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * -cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * -cameraRelative_Right *
						Time.fixedDeltaTime * delta);
				}
			} else if(onFloorTracker == 0) {
				// in air
				if(x_speed < airSpeed) {
					myBody.AddForce ((airSpeed * 0.75f) * -cameraRelative_Right
						* Time.fixedDeltaTime * delta);
				}

				if (z_speed > 0.1f) {
					if (z_Vel.normalized == cameraRelative_Up) {
						myBody.AddForce ((airSpeed * 0.75f) * -cameraRelative_Up
							* Time.fixedDeltaTime * delta);	
					} else if (z_Vel.normalized == -cameraRelative_Up) {
						myBody.AddForce ((airSpeed * 0.75f) * cameraRelative_Up
							* Time.fixedDeltaTime * delta);
					}
				}

			}

			break;

		}
	}

	void UpdateCameraRelativePosition() {

		// You need to understand the difference between local space and world space. 
		// Local is for directions and rotations relative to the object, 
		// and world is relative to the game world. 
		// This function takes a local direction from an object and finds 
		// that direction in world space. 
		// Vector3(1,0,0) is the same as Vector3.right, 
		// which in the object's local space is the direction 
		// pointing to the right of the object. 
		// Depending on how the object is rotated, the output in world space will change.

		// To understand TransformDirection, you must first understand the difference 
		// in World and Local space. 
		// Now, TransformDirection, as per the docs, transform a Vector from local 
		// space to world space. In the world space, vector (1,0,0) 
		// is one unit to the right of the origo, in local space, 
		// however that same vector is one step to the right based 
		// on the object's current rotation. 
		// What Transform direction does is it takes that relative movement, 
		// and returns how it is in relation to the origo.
		// You can see this effect for yourself if you imagine your monitor 
		// being the center of the world (0,0,0). 
		// The direction the back of your screen shows, 
		// is the positive z-axis(world forward), the direction the 
		// right edge of the screen is the positive x-axis (world right), 
		// and up is the positive y-axis (world up). 
		// Now, as long as you face your monitor, i.e. your(=local) forward is 
		// the same as the world (=your monitor) forward and your(=local) right 
		// is the same as the world right.
		// Now, if you turn so that your left is towards the monitor, 
		// the directions don't match anymore; your(=local) forward is suddenly 
		// pointing to the same direction as world right! 
		// But say you are blind and want to know which way you're actually 
		// facing in relation to the monitor. You'd need to do 
		// you.TransformDirection(you.forward) and that would return (1,0,0), 
		// which is equal to the world right.
		// The code you posted returns the x-axis (i.e. way right) for the current 
		// object in world space. The same can be achieved by simply using 
		// transform.right, because transform.direction is just shorthand for this translation.

		// EXPLANTION TO transform.TransformDirection
		// http://answers.unity3d.com/questions/506740/i-need-help-understanding-transformdirection.html

		cameraRelative_Right = mainCamera.transform.TransformDirection (Vector3.right);
		cameraRelative_Up = mainCamera.transform.TransformDirection (Vector3.forward);
		cameraRelative_Up.y = 0f;
		cameraRelative_Up = cameraRelative_Up.normalized;

		cameraRelative_Up_Right = (cameraRelative_Up + cameraRelative_Right);
		cameraRelative_Up_Right = cameraRelative_Up_Right.normalized;

		cameraRelative_Up_Left = (cameraRelative_Up - cameraRelative_Right);
		cameraRelative_Up_Left = cameraRelative_Up_Left.normalized;


		// Think of it this way... a Vector holds 2 pieces of information - 
		// a point in space and a magnitude. 
		// The magnitude is the length of the line formed between (0, 0, 0) 
		// and the point in space. If you "normalize" a vector 
		// (also known as the "unit vector" - Google it), 
		// the result is a line that starts a (0, 0, 0) and "points" to your original 
		// point in space. If you were to take the length of this "pointer" 
		// it would equal 1 unit length

		// A Vector2 is either a point or a direction, 
		// depending on what you use it for. For example, if it's (5, 0), 
		// then it's either a point at x=5, y=0, or it's a vector pointing 
		// along the positive x axis with a slope of 0 and a length of 5. 
		// In this case it's not normalized since the length is greater than 1. 
		// If you normalize it, then it will become (1, 0) and will have a length of 1.

		// EXPLANATION OF NORMALIZED ALSO GOOGLE IT
		// https://forum.unity3d.com/threads/what-is-vector3-normalize.164135/
		// http://answers.unity3d.com/questions/47363/what-is-vector3normalized.html

	}

	void FullSpeedController() {
		if (direction != directionLastFrame) {
			if (direction == "") {
				StopCoroutine ("FullSpeedTimer");
				fullSpeed = false;
			} else if (directionLastFrame == "") {
				StartCoroutine ("FullSpeedTimer");
			}
		}
	}

	IEnumerator FullSpeedTimer() {
		yield return new WaitForSeconds (0.07f);
		fullSpeed = true;
	}

	void DragAdjustmentAndAirSpeed() {
		if (onFloorTracker > 0) {
			// on the floor
			myBody.drag = floorDrag;
		} else {
			// in air
			x_Vel = Vector3.Project(myBody.velocity, cameraRelative_Right);
			z_Vel = Vector3.Project (myBody.velocity, cameraRelative_Up);

			x_speed = x_Vel.magnitude;
			z_speed = z_Vel.magnitude;

			myBody.drag = air_drag;

			// EXPLANATION WHAT IS MAGNITUDE
			// The magnitude is the distance between the vector's origin (0,0,0) 
			// and its endpoint. If you think of the vector as a line, 
			// the magnitude is equal to its length.
			// With two vectors, a and b, then (a-b).magnitude is the distance between them.
			// That's what Vector3.Distance() does actually. 
			// Since rigidbody.velocity is a vector, 
			// then rigidbody.velocity.magnitude is how fast a rigidbody is going.
			// https://forum.unity3d.com/threads/what-is-vector3-magnitude.50125/
			// https://docs.unity3d.com/ScriptReference/Vector3-magnitude.html


		}
			
	}

	void BallFellDown() {
		if (transform.position.y < -30f) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}

	void OnCollisionEnter(Collision target) {
		if (target.gameObject.tag == "Floor") {
			onFloorTracker++;
		}
	}

	void OnCollisionExit(Collision target) {
		if (target.gameObject.tag == "Floor") {
			onFloorTracker--;
		}
	}

} // class









































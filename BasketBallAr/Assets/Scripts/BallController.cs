using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public GameObject ballPrefab;

    // Fps cam stuff
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2}
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 5f;
    public float sensitivityY = 5f;

    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationY = 0f;
    public float throwForce = 0f;
    public float forceStep = 0.75f;
    float throwForceMax = 12f;
    float throwForceMin = 4f;
    public Slider forceSlider;

	// Use this for initialization
	void Start () {
        var rigidBodyComponent = GetComponent<Rigidbody>();
		if (rigidBodyComponent != null)
        {
            rigidBodyComponent.freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // camera update
        //if (axes == RotationAxes.MouseXAndY)
        //{
        //    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        //    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        //    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        //}
        //else if (axes == RotationAxes.MouseX)
        //{
        //    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        //}
        //else
        //{
        //    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        //    transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        //}

        //// ball throwing
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    throwForce += forceStep * Time.deltaTime;
        //    throwForce = Mathf.Clamp(throwForce, throwForceMin, throwForceMax);

        //} else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    throwBall();
        //    throwForce = 0f;
        //}
	}

    private void throwBall()
    {
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var ballRigidBody = ball.GetComponent<Rigidbody>();
        ballRigidBody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
    
    public void onForceSliderDragStop()
    {
        throwForce = forceSlider.value;
        throwBall();
        throwForce = 0f;
        forceSlider.value = 0f;
    }
}

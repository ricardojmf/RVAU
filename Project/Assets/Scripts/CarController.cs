using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    private float force;
    private float angleDirection;
	private bool onGround;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

		force = 0;
        angleDirection = 0;
		onGround = false;

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void FixedUpdate()
	{
		if (GetComponent<Collider>().enabled) {

			Vector3 perpendiculVect = GetComponentInParent<Transform> ().up.normalized;
			rb.AddForce (perpendiculVect * -20);

			if(onGround)
			{
				transform.Translate (new Vector3 (0, 0, force * Time.deltaTime), Space.Self);
				transform.Rotate (new Vector3 (0, angleDirection * 2 * Time.deltaTime, 0), Space.Self);
			}
		}

	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.CompareTag ("Ground"))
			onGround = true;
		else
			GetComponent<AudioSource> ().Play ();
	}

	void OnCollisionExit(Collision collision) {

		if (collision.gameObject.CompareTag ("Ground"))
			onGround = false;
	}

    public void SetAngleDirection(float val)
    {
        angleDirection = val;
    }

    public void SetForce(float val)
    {
		force = val;
    }
}

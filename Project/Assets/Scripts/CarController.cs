using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {


    private float force;
    private float angleDirection;
    private GameObject[] barrels;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		force = 0;
        angleDirection = 0;

        GameObject barrelSet = GameObject.FindGameObjectWithTag("Barrel");
        barrels = barrelSet.GetComponentsInChildren<GameObject>();

        string numBarrels = barrels.GetLength.ToString();

        //Debug.Log(barrels.GetLength.ToStri);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void FixedUpdate()
	{

		transform.Translate (new Vector3 (0, 0, force * Time.deltaTime), Space.Self);
		transform.Rotate (new Vector3 (0, angleDirection * Time.fixedDeltaTime, 0), Space.Self);

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrel"))
        {
            other.gameObject.SetActive(false);
        }
            
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

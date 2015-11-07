using UnityEngine;
using System.Collections;
using Vuforia;

public class PlayerController : MonoBehaviour {

    private float targetInitialPosition;
	private bool enable;
	private TrackableBehaviour mTrackableBehaviour;

    public CarController carController;


	// Use this for initialization
	void Start () {

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		enable = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (mTrackableBehaviour.CurrentStatus.Equals (TrackableBehaviour.Status.TRACKED)) {
			if (enable) {

				float angleDirection;

				if(transform.eulerAngles.x < 180)
					angleDirection = transform.eulerAngles.x;
				else
					angleDirection = transform.eulerAngles.x - 360;

				carController.SetAngleDirection (angleDirection);
				carController.SetForce (transform.localPosition.x - targetInitialPosition);
			

			} else {

				targetInitialPosition = transform.localPosition.x;
				enable = true;

			}
		} else {

			carController.SetAngleDirection (0);
			carController.SetForce (0);

			enable = false;
		}
	}
}

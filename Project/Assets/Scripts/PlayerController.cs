using UnityEngine;
using System.Collections;
using Vuforia;

public class PlayerController : MonoBehaviour {

    private float targetInitialPosition;
    private float targetInitialRotation;
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
				float force;
					
				float targetRotation = (transform.eulerAngles.x + 360 - targetInitialRotation) % 360;
					
				if (targetRotation > 180)
					angleDirection = 360 - targetRotation;
				else
					angleDirection = -targetRotation;

				force = (transform.localPosition.x - targetInitialPosition);

				carController.SetAngleDirection (angleDirection);
				carController.SetForce (force);

				Debug.Log (angleDirection);

			} else {

				targetInitialPosition = transform.localPosition.x;
				targetInitialRotation = transform.localRotation.eulerAngles.x;

				enable = true;

			}
		} else {

			carController.SetAngleDirection (0);
			carController.SetForce (0);

			enable = false;
		}
	}  

}

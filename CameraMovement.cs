using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject Character;

	void FixedUpdate () {
		this.transform.localPosition = new Vector3 (
			Character.transform.localPosition.x,
			Character.transform.localPosition.y,
			this.transform.localPosition.z);
	}
}

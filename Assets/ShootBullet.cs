using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ShootBullet : MonoBehaviour,IInputClickHandler {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		InputManager.Instance.PushFallbackInputHandler(gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
		
	public void OnInputClicked(InputClickedEventData eventData)
	{
		Vector3 shootDir = Camera.main.transform.forward.normalized;

		GameObject bulletIntance = Instantiate (bullet);
		bulletIntance.GetComponent<Rigidbody> ().AddForce (shootDir * 300f);
	}
}

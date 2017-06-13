using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class InkBullet : MonoBehaviour {
	public Es.InkPainter.Brush brush;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		var canvas = col.gameObject.GetComponent<InkCanvas> ();
		//var canvas = gameObject.GetComponent<InkCanvas>();
		if (canvas!=null) {
			canvas.Paint (brush, col.contacts [0].point);
			Destroy (gameObject);
		}
	}

}

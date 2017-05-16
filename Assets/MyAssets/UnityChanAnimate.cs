using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnityChanAnimate : MonoBehaviour {

	NavMeshAgent agent;
	Animator animator;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		var speed = agent.velocity.magnitude / transform.localScale.y;
		animator.SetFloat("Speed", speed);
	}
	
}

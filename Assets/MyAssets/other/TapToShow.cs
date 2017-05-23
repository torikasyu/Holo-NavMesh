using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.AI;

public class TapToShow : MonoBehaviour, IInputClickHandler
{
	public GameObject bullet;

	void Start()
	{
		InputManager.Instance.PushFallbackInputHandler(gameObject);
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		if (GazeManager.Instance.IsGazingAtObject)
		{
			GameObject go = Instantiate (bullet);
			Rigidbody rb = go.GetComponent<Rigidbody> ();
			rb.AddForce (new Vector3 (0f, 0f, 100f));
		}
	}
}
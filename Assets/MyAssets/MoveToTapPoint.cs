using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTapPoint : MonoBehaviour, IInputClickHandler
{
	public NavMeshAgent Agent;
	LineRenderer lineRenderer;

	void Start()
	{
		InputManager.Instance.PushFallbackInputHandler(gameObject);
		Agent.gameObject.SetActive(false);
		lineRenderer = gameObject.GetComponent<LineRenderer>();
		lineRenderer.positionCount = 0;
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		if (GazeManager.Instance.IsGazingAtObject)
		{
			var hitInfo = GazeManager.Instance.HitInfo;
			if (!Agent.gameObject.activeSelf)
			{
				Agent.gameObject.SetActive(true);
				Agent.transform.position = hitInfo.point;
			}
			else
			{
				Agent.destination = hitInfo.point;

				// パスの計算
				var path = new NavMeshPath();
				NavMesh.CalculatePath(Agent.transform.position, Agent.destination, NavMesh.AllAreas, path);
				var positions = path.corners;

				// ルートの描画
				lineRenderer.widthMultiplier = 0.1f;
				lineRenderer.positionCount = positions.Length;
				for (int i = 0; i < positions.Length; i++)
				{
					Debug.Log("point " + i + "=" + positions[i]);
					lineRenderer.SetPosition(i, positions[i]);
				}
			}
		}
	}
}
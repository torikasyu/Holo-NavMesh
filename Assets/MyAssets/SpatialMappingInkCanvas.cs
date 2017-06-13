using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;
using HoloToolkit.Unity;

public class SpatialMappingInkCanvas : MonoBehaviour {
	public GameObject SpatialMapping;
	public Material material;

	private void Awake () {
		var spatialMappingSources = SpatialMapping.GetComponents<SpatialMappingSource>();
		foreach (var source in spatialMappingSources)
		{
			source.SurfaceAdded += SpatialMappingSource_SurfaceAdded;
			source.SurfaceUpdated += SpatialMappingSource_SurfaceUpdated;
		}
	}

	void Start()
	{
	}

	private void SpatialMappingSource_SurfaceAdded(object sender, DataEventArgs<SpatialMappingSource.SurfaceObject> e)
	{
		//e.Data.Object.AddComponent<NavMeshSourceTag>();
		//Es.InkPainter.InkCanvas ic = new Es.InkPainter.InkCanvas();
		//ic.SetPaintMainTexture ("Sample");
		//ic.SetPaintNormalTexture ("Sample");

		//RenderTexture rt = new RenderTexture (256, 256, 16);
		//rt.Create ();

		e.Data.Object.AddComponent<Es.InkPainter.InkCanvas>();
		//e.Data.Object.GetComponent<MeshRenderer> ().material = this.material;
	}

	private void SpatialMappingSource_SurfaceUpdated(object sender, DataEventArgs<SpatialMappingSource.SurfaceUpdate> e)
	{
		var ic = e.Data.New.Object.GetComponent<Es.InkPainter.InkCanvas>();
		if(ic == null)
		{
			e.Data.New.Object.AddComponent<Es.InkPainter.InkCanvas>();
			//e.Data.New.Object.GetComponent<MeshRenderer> ().material = this.material;
		}

	}
}
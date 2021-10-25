using UnityEngine;

public class CameraToAspectRatioAdapter : MonoBehaviour {

	[SerializeField] float targetAspect = 16f/9f;

	void Start () 
	{
		float windowAspect = (float)Screen.width / (float)Screen.height;
		float scaleHeight = windowAspect/targetAspect;
		Camera camera = GetComponent<Camera>();

		if (scaleHeight < 1f)
		{
			Rect rect = camera.rect;

			rect.width = 1f;
			rect.height = scaleHeight;
			rect.x = 0f;
			rect.y = (1f - scaleHeight) / 2f;

			camera.rect = rect;
		}
		else 
		{
			float scaleWidth = 1f / scaleHeight;

			Rect rect = camera.rect;
			
			rect.width = scaleWidth;
			rect.height = 1f;
			rect.x = (1f - scaleWidth) / 2f;
			rect.y = 0f;
			
			camera.rect = rect;
		}
	}
}

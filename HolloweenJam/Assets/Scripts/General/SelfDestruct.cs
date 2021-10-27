using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	#region Fields
	[SerializeField] float delay = 0f;
	#endregion

	#region Callbacks
	void Start ()
	{
		StartDestruction();
	}
	#endregion

	void StartDestruction () {
		Destroy(gameObject, delay);
	}
}

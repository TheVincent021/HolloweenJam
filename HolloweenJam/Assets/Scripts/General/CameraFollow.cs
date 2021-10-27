using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{

	[SerializeField] Transform target;
	[SerializeField] [Range(0f, 1f)] float followStiffness = 0.2f;

	Vector3 offset;

	Transform m_Transform;

	// To make refrences
	void Awake ()
	{
		m_Transform = transform;
	}

	// Use this for initialization
	void Start () 
	{
		offset = m_Transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		m_Transform.position = Vector3.Lerp(m_Transform.position, target.position + offset, followStiffness);
	}
}

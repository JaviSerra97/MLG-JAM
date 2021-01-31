using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public Transform camTransform;
	public float shakeAmount = 0.7f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			originalPos = camTransform.localPosition;
			Debug.Log("EnterIN");
		}
		Debug.Log("Enter");
	}

    private void OnTriggerStay(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			Debug.Log("StayIN");
		}
		Debug.Log("Stay");
	}

    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			camTransform.localPosition = originalPos;
			Debug.Log("ExitIN");
		}
		Debug.Log("Exit");
	}
}

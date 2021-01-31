using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.CompareTag("Player"))
        {
			originalPos = camTransform.localPosition;
			Debug.Log("EnterIN");
		}
		Debug.Log("Enter");
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			Debug.Log("StayIN");
        }
		Debug.Log("Stay");
	}

    private void OnCollisionExit(Collision collision)
    {
		if (collision.gameObject.CompareTag("Player"))
        {
			camTransform.localPosition = originalPos;
			Debug.Log("ExitIN");
		}
		Debug.Log("Exit");
	}
}

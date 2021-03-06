﻿using UnityEngine;
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
		}
	}

    private void OnTriggerStay(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
		}
	}

    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			camTransform.localPosition = originalPos;
		}
	}
}

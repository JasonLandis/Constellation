using UnityEngine;

public class RotateMeteor : MonoBehaviour
{
	private Vector3 rotationSpeed;

	void OnEnable()
	{
		rotationSpeed = new Vector3(0, 0, Random.Range(-100f, 100f));
    }
    void Update()
    {
		transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
	}
}

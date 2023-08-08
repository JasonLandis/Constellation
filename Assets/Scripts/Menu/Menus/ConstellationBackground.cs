using UnityEngine;

public class ConstellationBackground : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        gameObject.transform.RotateAround(target.transform.position, Vector3.forward, 2 * Time.deltaTime);
    }
}

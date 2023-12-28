using UnityEngine;

public class EndObject : MonoBehaviour
{
    public float rotFl;

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, -Mathf.PingPong(Time.time * 50, rotFl), 0);
    }
}

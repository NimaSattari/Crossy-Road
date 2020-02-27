using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool autoMove = true;
    public GameObject player;
    public float speed = 1.0f;
    public Vector3 offset = new Vector3(1, 1, -1);
    Vector3 depth = Vector3.zero;
    Vector3 pos = Vector3.zero;

    private void Update()
    {
        if (!Manager.insance.CanPlay()) return;
        if (autoMove)
        {
            depth = this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);
        }
        else
        {
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, pos.z);
        }
    }
}

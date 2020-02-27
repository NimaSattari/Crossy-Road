using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1.0f;
    public float moveDirection = 0;
    public bool parentOnTrigger = true;
    public bool hitBoxOnTrigger = false;
    public GameObject moverObject = null;

    private Renderer renderer = null;
    private bool isVisible = false;

    private void Start()
    {
        renderer = moverObject.GetComponent<Renderer>();
    }
    private void Update()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
        IsVisible();
    }
    void IsVisible()
    {
        if (renderer.isVisible)
        {
            isVisible = true;
        }
        if(!renderer.isVisible && isVisible)
        {
            Debug.Log("Remove object. No longer seen by camera.");

            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (parentOnTrigger)
            {
                other.transform.parent = this.transform;
                other.GetComponent<PlayerController>().parentedToObject = true;
            }
            if (hitBoxOnTrigger)
            {
                other.GetComponent<PlayerController>().GotHit();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (parentOnTrigger)
            {
                other.transform.parent = null;
                other.GetComponent<PlayerController>().parentedToObject = false;

            }
        }
    }
}

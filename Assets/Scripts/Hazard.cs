using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*if (gameObject.name == "Big Rolling Obstacle")
        {
            transform.position = new Vector3(52.6f, 55.7f, 55f);
        }
        else if (gameObject.name == "Small Rolling Obstacle")
        {
            transform.position = new Vector3(-55.7f, 51f, 110f);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}

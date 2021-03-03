using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] float verticalForce = 400f;
    [SerializeField] float horizontalForce = 150f;
    [SerializeField] float lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(
            Random.Range(-horizontalForce, horizontalForce),
            verticalForce,
            0
        ));
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0) {
            Destroy(gameObject);
        }
    }
}

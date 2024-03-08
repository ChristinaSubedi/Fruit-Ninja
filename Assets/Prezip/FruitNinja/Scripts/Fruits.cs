using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject slicedFruit;
    public GameObject fruitJuice;
    private float rotationForce = 200f;
    // Start is called before the first frame update
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);//rotate while on screen continuously
    }

    private void InstantiateSlicedFruit()
    {
        GameObject instantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instantiatedJuice = Instantiate(fruitJuice, new Vector3(transform.position.x, transform.position.y, 0), fruitJuice.transform.rotation);
        Rigidbody[] slicedRb = instantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(130f, transform.position, 20);//so that the two part flies in 2 diff direction with force of 130f, randius 10
            srb.velocity = rb.velocity * 1.2f;//when it splits, get extra velocity
        }

        Destroy(instantiatedFruit, 5);//destroys the fruit after 5 second
        Destroy(instantiatedJuice, 5);//destroys the fruit after 5 second


    }

    private void OnTriggerEnter(Collider other)//
    {
        if (other.tag == "Blade")
        {
            Destroy(gameObject);
        }
        InstantiateSlicedFruit();
    }
}

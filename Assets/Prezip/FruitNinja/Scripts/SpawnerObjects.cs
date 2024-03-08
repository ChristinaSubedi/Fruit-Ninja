using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    public GameObject[] objects;//array of fruits and bomb
    public float left;//are the fruits moving left or right ( don#t want out of screen)
    public float right;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());//to do stuff concurrently
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            InstantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatrate());//fly fruit after a couple of seconds

        }
    }

    // Update is called once per frame
    private void InstantiateRandomObject()
    {
        int objectIndex = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[objectIndex],transform.position, objects[objectIndex].transform.rotation);
        obj.GetComponent<Rigidbody>().AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);//force in upwards dir

        obj.transform.rotation= Random.rotation;//rotate things randomly
    }

    private float RandomForce()
    {
        float force = Random.Range(14f, 16f);
        return force;
    }

    private float RandomRepeatrate()
    {
        float repeatrate = Random.Range(0.5f, 3f);
        return repeatrate;
    }

    private Vector2 RandomVector()
    {
        //normalise so that it always is 1, if not it could go less high or more high and so
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;//upwards between the leftmost and rightmost part of screen
        return moveDirection;
    }
}

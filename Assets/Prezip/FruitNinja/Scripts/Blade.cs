using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private SphereCollider sc;
    private TrailRenderer tr;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        sc= GetComponent<SphereCollider>();//only when we click with sth
        tr= GetComponent<TrailRenderer>();//
    }

    // Update is called once per frame
    void Update()
    {
        BladeFollowMouse();
        if (Input.GetMouseButtonDown(0))//when we click left (1, right)
        {
            tr.enabled = true;
            sc.enabled = true;
        }

        if (Input.GetMouseButtonUp(0)) {//when we release mouse
            tr.enabled= false;
            sc.enabled = false;
        }

    }

    private void BladeFollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8;// fruits at pos 2, camera at pos 10 so 10-2 =8
        rb.position=Camera.main.ScreenToWorldPoint(mousePos);
    }
}

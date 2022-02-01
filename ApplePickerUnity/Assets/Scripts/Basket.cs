using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's Z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePad3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePad3D.x;
        this.transform.position = pos;

    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
    }
}

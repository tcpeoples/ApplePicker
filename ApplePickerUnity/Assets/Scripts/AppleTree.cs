/**
 * Created By: Tyrese Peoples
 * Date Created: Jan. 31, 2022
 * 
 * Last Edited By: Tyrese Peoples
 * Last Edited: Jan. 31 2022
 * 
 * Description: Controls the movement of the AppleTree
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    /****VARIABLES****/

    [Header("Set in Inspector")]
    public float speed = 1f; //tree speed
    public float leftAndRightEdge = 10f; //distance where the tree turns around
    public GameObject applePrefab; //prefab for instantiating apples
    public float secDrops = 1f; //time between apple drops
    public float chanceToChangeDirections = 0.1f; // chance that the tree will change directions

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke( "DropApple", 2f);
    }// end start


    void DropApple()
    {
        GameObject Apple = Instantiate<GameObject>(applePrefab);
        Apple.transform.position = transform.position;
        Invoke( "DropApple", secDrops);
    }


    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position; //records current position
        pos.x += speed * Time.deltaTime; // adds speed to x position
        transform.position = pos; //apply the position value

        //Change Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //set speed to postive
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //set speed to negative value
        }//end change directions
    } // end update

    
    //Fixed Update is called on fixed intervals (50 times per second)

    private void FixedUpdate()
    {
        //Test chance of direction change
        if(Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change directions

        }
    } // end fixed update

}

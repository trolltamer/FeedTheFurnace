using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Player Manager is responsible for handling input and allowing the player to drag and drop gameobjects with collider2d's attached to them.
 */

public class PlayerManager : MonoBehaviour {

    GameObject clickedObject = null;

    private float heldTime;
    private float maxHeldTime = 1.5f;
    private float dragSpeed = 8f;

	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosWorldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition);

            RaycastHit2D ray2D = Physics2D.Raycast(mousePosWorldPos, Vector3.forward);

            if(ray2D.collider != null && ray2D.collider.attachedRigidbody.bodyType != RigidbodyType2D.Static)
            {
                clickedObject = ray2D.collider.gameObject;
                clickedObject.GetComponent<Spawnable>().currentlyHeld = true;
            }
        }

        if(clickedObject != null)
        {
            heldTime += Time.deltaTime;

            if(heldTime > maxHeldTime || Input.GetMouseButtonUp(0))
            {
                DropClickedObject();
            }
        }        
	}


    private void FixedUpdate()
    {
        if(clickedObject != null)
        {
            MoveToMouse(clickedObject.GetComponent<Rigidbody2D>());
        }
    }

    private void MoveToMouse(Rigidbody2D targetRB2D)
    {
        Vector3 mousePosWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)mousePosWorldPos - targetRB2D.position;

        targetRB2D.velocity = direction * dragSpeed;
    }

    private void DropClickedObject()
    {
        clickedObject.GetComponent<Spawnable>().currentlyHeld = false;
        clickedObject = null;
        heldTime = 0f;
    }
}

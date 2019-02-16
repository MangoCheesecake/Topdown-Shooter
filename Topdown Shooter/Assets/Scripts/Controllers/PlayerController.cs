using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour 
{
	public float movementSpeed;
	public bool canMove;
	private Rigidbody2D rbody;

    public Gun gun;

	void Start () 
	{
        canMove = true;
		rbody = GetComponent<Rigidbody2D> ();
    }

	void FixedUpdate  () 
	{
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        Vector2 movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        rbody.MovePosition(rbody.position + movementVector * Time.deltaTime * movementSpeed);
    }
}

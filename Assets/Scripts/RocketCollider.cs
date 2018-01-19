using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Final                         //
//                       Friday, January 19, 2018                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////
public class RocketCollider : MonoBehaviour
{

	bool fired;
	private Rigidbody2D _rb = null;
	private Transform _transform = null;
	private Vector2 _currentPos;

	[SerializeField]
	float force = 1000f;
	[SerializeField]
	float forceStep = 1f;
	[SerializeField]
	float forceChange = 0f;
	[SerializeField]
	float rotation = 0f;
	[SerializeField]
	float step = 5f;
	[SerializeField]
	Text angleText;
	[SerializeField]
	Text forceText;
	[SerializeField]
	GameObject rocket;
	[SerializeField]
	Transform spawn;
	[SerializeField]
	GameObject explosion;


	// Use this for initialization
	void Start()
	{
		fired = false;
		_rb = gameObject.GetComponent<Rigidbody2D>();
		_transform = gameObject.GetComponent<Transform>();

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		rotation = Input.GetAxis("Vertical");

		if (rotation > 0 && transform.rotation.eulerAngles.z <= 90)
		{
			_transform.Rotate(0, 0, 50 * Time.deltaTime);
		}
		if (rotation < 0 && transform.rotation.eulerAngles.z > 1)
		{
			_transform.Rotate(0, 0, -50 * Time.deltaTime);
		}
		
		angleText.text = "Angle: " + transform.rotation.eulerAngles.z.ToString();
		
		forceChange = Input.GetAxis("Horizontal");
		Vector2 forceVect = new Vector2(
			forceChange,
			0
		);
		_rb.AddForce(forceVect * force);
		if (forceChange > 0)
		{
			force += forceStep;
		}
		if (forceChange < 0)
		{
			force-= forceStep;
			if (force < 0)
			{
				force = 0;
			}
		}
		
		forceText.text = "Force: " + force.ToString();

		if (Input.GetButtonDown("Fire1") && !fired)
		{
			fired = true;
			_rb.bodyType = RigidbodyType2D.Dynamic;
			_rb.AddRelativeForce(Vector2.right * force);
			Debug.Log("101015270-fire");

		}
		_currentPos = gameObject.transform.position;
		gameObject.transform.position = _currentPos;
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
	    if (other.gameObject.tag.Equals("killzone"))
	    {
	        gameObject.transform.position = spawn.position;
	        _rb.velocity = Vector2.zero;
	        _rb.angularVelocity = 0;
	        _rb.bodyType = RigidbodyType2D.Kinematic;
	        gameObject.transform.eulerAngles = Vector3.zero;
	        fired = false;
	    }

	    if (other.gameObject.tag.Equals("target"))
	    {
	        SceneManager.LoadScene("gameOver");

	    }


	    if (other.gameObject.tag.Equals("stone"))
		{
			other.gameObject.GetComponent<ObstacleManager>().DestroyMe();
			gameObject.transform.position = spawn.position;
			_rb.bodyType = RigidbodyType2D.Kinematic;
			fired = false;
			_rb.velocity = Vector2.zero;
			_rb.angularVelocity = 0;
			Instantiate(explosion)
				.GetComponent<Transform>()
				.position = other.gameObject
				.GetComponent<Transform>()
				.position;
		}

	}
}

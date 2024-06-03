using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class ObiRopeManager : MonoBehaviour
{
	public static ObiRopeManager instance;
	ObiRopeCursor cursor;
	ObiRope rope;
	public float minLength = 0.1f;
	public float speed = 1;
	public float maxLength = 1;

    private void Awake()
    {
		rope = GetComponent<ObiRope>();
		cursor = GetComponent<ObiRopeCursor>();
		cursor.ChangeLength(0f);
		Debug.Log("aaa");
	}
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
        if (rope.restLength < maxLength)
        {
            cursor.ChangeLength(rope.restLength + speed * Time.deltaTime);
            Debug.Log(rope.restLength);
        }
    }

	public void ChangeValue()
    {
		cursor.ChangeLength(0f);
		Debug.Log("aaa");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;

    //cache component references
    GameSession theGameSession;
    Ball theBall;

    // Use this for initialization
    void Start () {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}

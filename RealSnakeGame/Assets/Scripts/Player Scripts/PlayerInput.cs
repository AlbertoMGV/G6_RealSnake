using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerController playerController;

    public string dir;

    private int horizontal = 0, vertical = 0;

    public enum Axis {
        Horizontal,
        Vertical
    }

	void Awake () {
        playerController = GetComponent<PlayerController>();
	}
	
	void Update () {

        horizontal = 0;
        vertical = 0;

        SetMovement();

	}

    void SetMovement() {

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (vertical != 0) {

            playerController.SetInputDirection((vertical == 1) ?
                                               PlayerDirection.UP : PlayerDirection.DOWN);


        } else if(horizontal != 0) {

            playerController.SetInputDirection((horizontal == 1) ?
                                               PlayerDirection.RIGHT : PlayerDirection.LEFT);

        }

    }

    public void Move(string dir)
    {

        switch (dir)
        {
            case "left":
                horizontal = -1;
                break;
            case "rigth":
                horizontal = 1;
                break;
            case "up":
                vertical = 1;
                break;
            case "down":
                vertical = -1;
                break;
        }

    }

} // class






































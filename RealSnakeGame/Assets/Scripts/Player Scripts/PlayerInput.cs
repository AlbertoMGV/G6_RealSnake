using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    private PlayerController playerController;

    private int horizontal = 0, vertical = 0;

    //private Text test1;

    public enum Axis {
        Horizontal,
        Vertical
    }

	void Awake () {
        playerController = GetComponent<PlayerController>();
        //test1 = GameObject.Find("test1").GetComponent<Text>();
    }
	
	void Update () {

        //horizontal = 0;
        //vertical = 0;

        //GetKeyboardInput();

        //SetMovement();

	}

    void GetKeyboardInput() {

        //horizontal = (int)Input.GetAxisRaw("Horizontal");
        //vertical = (int)Input.GetAxisRaw("Vertical");

        horizontal = GetAxisRaw(Axis.Horizontal);
        vertical = GetAxisRaw(Axis.Vertical);

        if (horizontal != 0) {
            vertical = 0;
        }

    }

    void SetMovement() {

        if(vertical != 0) {

            playerController.SetInputDirection((vertical == 1) ?
                                               PlayerDirection.UP : PlayerDirection.DOWN);


        } else if(horizontal != 0) {

            playerController.SetInputDirection((horizontal == 1) ?
                                               PlayerDirection.RIGHT : PlayerDirection.LEFT);

        }
        horizontal = 0;
        vertical = 0;

    }

    int GetAxisRaw(Axis axis) {

        if(axis == Axis.Horizontal) {

            bool left = Input.GetKeyDown(KeyCode.LeftArrow);
            bool right = Input.GetKeyDown(KeyCode.RightArrow);

            if(left) {
                return -1;
            }

            if(right) {
                return 1;
            }

            return 0;

        } else if(axis == Axis.Vertical) {

            bool up = Input.GetKeyDown(KeyCode.UpArrow);
            bool down = Input.GetKeyDown(KeyCode.DownArrow);

            if(up) {
                return 1;
            }

            if(down) {
                return -1;
            }

            return 0;

        }

        return 0;
    }

    public void Move(string dir)
    {

        switch (dir)
        {
            case "left":
                horizontal = -1;
                //test1.text = "left";
                SetMovement();
                break;
            case "rigth":
                horizontal = 1;
                //test1.text = "rigth";
                SetMovement();
                break;
            case "up":
                vertical = 1;
                //test1.text = "up";
                SetMovement();
                break;
            case "down":
                vertical = -1;
                //test1.text = "down";
                SetMovement();
                break;
        }

    }


} // class






































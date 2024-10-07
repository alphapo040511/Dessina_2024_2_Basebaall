using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    None = 0,
    Up = 1,
    Down = 2,
    Left = 10,
    Right = 20,
    LeftUp = 11,
    LeftDown = 12,
    RightUp = 21,
    RightDown = 22
}

public enum InputData
{
    up = 1,
    down = 2,
    left = 10,
    right = 20
}

public class InputManager : MonoBehaviour
{
    private List<InputData> inputList = new List<InputData> { };
    private Timer inputTimer = new Timer(0.05f);

    public BallManager ballMangaer;

    public Direction temp;

    private void Start()
    {
        inputTimer.ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
        InputCheck();

        if (inputList.Count > 0)
        {
            inputTimer.TimeUpdata(Time.deltaTime);
        }

        if (inputList.Count >= 2 || inputTimer.ReadyCheck())
        {
            inputTimer.ResetTimer();
            int index = 0;
            foreach(int i in inputList)
            {
                index += i;
            }
            DirectionCheck(index);
            inputList.Clear();
        }
    }

    private void DirectionCheck(int index)
    {
        temp = (Direction)index;
        ballMangaer.HitBall(temp);
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddInput(InputData.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddInput(InputData.down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddInput(InputData.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddInput(InputData.right);
        }
    }

    private void AddInput(InputData input)
    {
        if (!inputList.Contains(input) && inputList.Count < 2)
        {
            inputList.Add(input);
            inputTimer.ResetTimer();
        }
    }
}

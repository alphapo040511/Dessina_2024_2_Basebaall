using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallData
{
    public Direction direction = Direction.None;
    public float arriveTime = 0;

    public BallData(Direction direction ,float arriveTime)
    {
        this.direction = direction;
        this.arriveTime = arriveTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallData
{
    private Direction direction = Direction.None;
    private float arriveTime = 0;
    private float nowTime = 0;

    public BallData(Direction direction ,float arriveTime, float nowTime)
    {
        this.direction = direction;
        this.arriveTime = arriveTime;
        this.nowTime = nowTime;
    }
}

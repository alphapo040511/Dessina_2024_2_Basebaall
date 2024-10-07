using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public GameObject[] ballImage = new GameObject[8];

    public Animator batterAnimator;

    private Dictionary<Direction, GameObject> ballImages = new Dictionary<Direction, GameObject> { };

    private BallData nowBallData;

    private void Start()
    {
        ballImages.Add(Direction.LeftUp, ballImage[0]);
        ballImages.Add(Direction.Up, ballImage[1]);
        ballImages.Add(Direction.RightUp, ballImage[2]);
        ballImages.Add(Direction.Left, ballImage[3]);
        ballImages.Add(Direction.Right, ballImage[4]);
        ballImages.Add(Direction.LeftDown, ballImage[5]);
        ballImages.Add(Direction.Down, ballImage[6]);
        ballImages.Add(Direction.RightDown, ballImage[7]);
        NewBall();
    }

    public void HitBall(Direction direction)
    {
        DOTween.Kill(ballImages[nowBallData.direction].transform);
        if(nowBallData.direction == direction)
        {
            Debug.Log("맞았다!");
            batterAnimator.SetTrigger("Hit");
        }
        else
        {
            Debug.Log("안 맞았다");
        }
        ArrivedBall(ballImages[nowBallData.direction]);
    }

    private void SetBall(BallData data)
    {
        nowBallData = data;
        BallImageSizeChange(nowBallData.direction, nowBallData.arriveTime);
    }

    void BallImageSizeChange(Direction direction, float time)
    {
        GameObject image = ballImages[direction];
        image.transform.localScale = Vector2.zero;
        image.SetActive(true);
        image.transform.DOScale(Vector2.one, time).SetEase(Ease.Linear).OnComplete(() => { ArrivedBall(image); });
    }

    void ArrivedBall(GameObject image)
    {
        image.SetActive(false);
        image.transform.localScale = Vector2.zero;
        NewBall();
    }

    public void NewBall()
    {
        Direction diretion = Direction.None;
        switch(Random.Range(0,8))
        {
            case 0:
                diretion = Direction.Up;
                break;
            case 1:
                diretion = Direction.Down;
                break;
            case 2:
                diretion = Direction.Left;
                break;
            case 3:
                diretion = Direction.Right;
                break;
            case 4:
                diretion = Direction.LeftUp;
                break;
            case 5:
                diretion = Direction.LeftDown;
                break;
            case 6:
                diretion = Direction.RightUp;
                break;
            case 7:
                diretion = Direction.RightDown;
                break;
        }
        BallData temp = new BallData(diretion, 1.5f);
        SetBall(temp);
    }
}

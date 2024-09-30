using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public Dictionary<Direction, Image> ballImages = new Dictionary<Direction, Image> { };

    public BallData ballData;

    public void NewBall(Direction direction)
    {
        ballImageSizeChange(ballImages[direction]);
    }

    void ballImageSizeChange(Image image)
    {
        image.enabled = true;
        image.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
    }
}

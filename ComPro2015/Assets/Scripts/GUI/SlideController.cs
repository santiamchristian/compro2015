using UnityEngine;
using System.Collections;

public class SlideController : MonoBehaviour {
    public float slideSpeed;
    public bool slidingDown { get; set; }

    void Update()
    {
        if (slidingDown)
        {

            ((RectTransform)transform).anchoredPosition = Vector3.Slerp(((RectTransform)transform).anchoredPosition, Vector3.zero, slideSpeed);
            if (((RectTransform)transform).anchoredPosition.y <= 0)
            {
                slidingDown = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] 
    private GameObject heartPoint;

    private void Update()
    {
        HeartPointMove();
    }

    private void HeartPointMove()
    {
        Vector3 pointPosition = new Vector3(ScoreController.Instance.ProgressScore, 0, 0);
        heartPoint.transform.localPosition = Vector3.Lerp(heartPoint.transform.localPosition, pointPosition, .1f);
        heartPoint.transform.localPosition = new Vector3(Mathf.Clamp(heartPoint.transform.localPosition.x, -286, 286),0, 0);
    }
}
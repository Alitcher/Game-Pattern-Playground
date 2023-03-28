using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        getpos = getRandomdiagnalPos[Random.Range(0, getRandomdiagnalPos.Length)];

        //  InvokeRepeating("MoveRandom", 0, 1f); //this is the first solution.
    }

    private float timeSec = 1f;
    private float currentTime;
    private bool isMoving;
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveRandomOnUpdate(); //this is the second solution.
    }

    private void MoveRandomOnUpdate() 
    {
        if (currentTime < timeSec)
        {
            currentTime += Time.deltaTime;
        }
        else 
        {
            currentTime = 0;
            //Walk(getpos,1);
            MoveRandom();
        }
    }

    Vector3 getpos;

    private void MoveRandom() 
    {
        this.transform.position += getpos.normalized * Time.deltaTime ;
        print(getpos);
    }

    private IEnumerator Walk(Vector3 direction, float duration)
    {
        Vector3 from = transform.position;
        Vector3 to = from + direction;

        if (duration < float.Epsilon)
        {
            transform.position = to;
            yield break;
        }

        isMoving = true;
        float agregate = 0;
        while (agregate < 1f)
        {
            agregate += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(from, to, currentTime);
            yield return null;
        }
        isMoving = false;
    }

    private Vector3[] getRandomdiagnalPos = { Vector3.up + Vector3.left, Vector3.up + Vector3.right, Vector3.down + Vector3.left, Vector3.down + Vector3.right,
    Vector3.up + Vector3.left + Vector3.forward, Vector3.up + Vector3.right+ Vector3.forward, Vector3.down + Vector3.left+ Vector3.forward, Vector3.down + Vector3.right+ Vector3.forward,
    Vector3.up + Vector3.left + Vector3.back, Vector3.up + Vector3.right+ Vector3.back, Vector3.down + Vector3.left+ Vector3.back, Vector3.down + Vector3.right+ Vector3.back};
}

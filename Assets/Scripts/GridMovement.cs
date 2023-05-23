﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour //receiver
{
    [SerializeField] private GridMovement nextTail;

    [SerializeField] private float moveTime = 0.3f;
    [SerializeField] private AnimationCurve spacing;

    //The script will not accept new move orders before previous is finished.
    private bool isMoving;
    private Animator animator;
    private MapInfo map;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("y", -1);
        map = FindObjectOfType<MapInfo>();
    }

    private void Update()
    {
        if (isMoving)
        {

        }
    }

    /// <summary>
    /// Walks to adjacent tile based on direction
    /// </summary>
    /// <param name="direction"></param>
    public bool Walk(Vector3 direction)
    {

        if (isMoving)
            return false;

        if (!IsPositionWalkable(transform.position + direction))
            return false;


        StartCoroutine(Walk(direction, moveTime));

        return true;

    }

    private bool IsPositionWalkable(Vector3 pos)
    {
        if (Physics2D.OverlapPoint(pos) != null)
            return false;

        if (map != null)
        {
            return map.IsPositionInBounds(pos);
        }

        return true;
    }

    private IEnumerator Walk(Vector3 direction, float duration)
    {
        Vector3 from = transform.position;
        Vector3 to = from + direction;

        MoveNext(from);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        animator.SetFloat("speed", 1f);
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
            transform.position = Vector3.Lerp(from, to, spacing.Evaluate(agregate));
            yield return null;
        }

        isMoving = false;
        animator.SetFloat("speed", 0f);
    }

    private void MoveNext(Vector3 position)
    {
        if (nextTail == null)
        {
            return;
        }

        //execute it on the corresponding next part of the character
        //MoveCommand moveCommand = new MoveCommand(KeyCode.None, "Move", position - nextTail.transform.position);
       //moveCommand.Execute(nextTail);
        nextTail.transform.position = position;
    }
}

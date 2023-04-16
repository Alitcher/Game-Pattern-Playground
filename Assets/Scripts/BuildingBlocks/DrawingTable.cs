using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DrawingTable : MonoBehaviour
{

    private int scale;
    private Transform activeParent;

    private bool[,] filledTiles = new bool[10,10];

    public void Start()
    {
        SetScale(10);
        StartNewDrawing();
    }

    public void StartNewDrawing()
    {
        activeParent = new GameObject($"Scale {scale} object").transform;
        Array.Clear(filledTiles, 0, filledTiles.Length);
    }

    public void AddPart(GameObject prototype, Vector3 position)
    {
        if (prototype == null)
        {
            Debug.Log($"No prototype selected.");
            return;
        }

        if (filledTiles[(int) position.x, (int) position.z])
            return;

        position.y += transform.position.y;
        GameObject copy = CreateCopy(prototype);
        copy.transform.position = position;
        copy.transform.parent = activeParent;
        filledTiles[(int) position.x, (int) position.z] = true;
    }

    private GameObject CreateCopy(GameObject prototype)
    {
        /*  Create a copy of the prototype gameobject and return it.
         *  To create gameobjects use the new GameObject() constructor
         *  To create components use the AddComponent() method
         *
         *  It is recommended to only account for the component types actually used
         *  in the drawing part. Use the hierarchy and inspector to figure out which
         *  components and fields we have to look for when cloning the objects. At
         *  scale 1 the drawing is being constructed under the "Scale 10 object" in
         *  the hierarcy.
         */

        GameObject copy = new GameObject(prototype.name + "_copy");

        foreach (Component component in prototype.GetComponentsInChildren<Component>())
        {
            if (component is MeshFilter)
            {
                MeshFilter meshFilter = copy.AddComponent<MeshFilter>();
                meshFilter.sharedMesh = (component as MeshFilter).sharedMesh;
            }
            else if (component is MeshRenderer)
            {
                MeshRenderer meshRenderer = copy.AddComponent<MeshRenderer>();
                meshRenderer.sharedMaterials = (component as MeshRenderer).sharedMaterials;
            }
            else if (component is BoxCollider)
            {
                BoxCollider boxCollider = copy.AddComponent<BoxCollider>();
                boxCollider.center = (component as BoxCollider).center;
                boxCollider.size = (component as BoxCollider).size;
            }
        }

        return copy;
        //return Instantiate(prototype);//original
    }

    public void Clear()
    {
        if(activeParent == null)
            return;
        
        Destroy(activeParent.gameObject);
        activeParent = null;
    }

    public GameObject GetDrawing()
    {
        return activeParent.gameObject;
    }

    public void SetScale(int value)
    {
        scale = value;
    } 

}

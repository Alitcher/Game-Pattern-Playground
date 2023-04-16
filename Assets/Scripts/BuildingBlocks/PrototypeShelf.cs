using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeShelf : MonoBehaviour
{

    public List<GameObject> Prototypes = new List<GameObject>();
    
    private const int TableSize = 10;

    public void AddPrototype(GameObject prototype)
    {
        Prototypes.Add(prototype);
        prototype.transform.parent = transform;
        prototype.transform.localPosition = new Vector3(0, 0, (Prototypes.Count - 1)  * 1.5f);
        prototype.transform.localScale = new Vector3(1f / TableSize, 1f / TableSize, 1f / TableSize);
    }

    public GameObject GetPrototypeRoot(Transform child)
    {
        while (true)
        {
            if (child.parent == null) return null;

            PrototypeShelf shelf = child.parent.GetComponent<PrototypeShelf>();
            if (shelf == null)
            {
                child = child.parent;
            }
            else
            {
                return child.gameObject;
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}

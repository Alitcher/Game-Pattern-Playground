using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingController : MonoBehaviour
{

    private static readonly Vector3 ShelfPosition = new Vector3(-1.5f, 0.5f, 0.5f);
    
    [Header("References")]
    public DrawingTable Table;
    public Text ScaleDisplay;

    [Header("Shelf Prefabs")]
    public PrototypeShelf EmptyShelf;
    public PrototypeShelf ScaleOnePrototypes;

    private Camera cam;
    private int scale = 1;
    private GameObject activePrototype;
    private Dictionary<int, PrototypeShelf> prototypeLibrary;

    private int NextScale => scale * 10;
    private int PreviousScale => scale / 10;

    // Start is called before the first frame update
    void Start()
    {
        prototypeLibrary = new Dictionary<int, PrototypeShelf>();
        PrototypeShelf scale1 = Instantiate(ScaleOnePrototypes);
        prototypeLibrary.Add(1, scale1);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!Input.GetMouseButton(0))
            return;
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        bool hitSomething = Physics.Raycast(ray, out RaycastHit hitInfo);
        if(!hitSomething)
            return;
        
        //Handle placement
        DrawingTable drawingTable = hitInfo.collider.GetComponent<DrawingTable>();
        if (drawingTable != null)
        {
            drawingTable.AddPart(activePrototype, hitInfo.point.Floored());
        }

        //Handle selection
        PrototypeShelf shelf = hitInfo.collider.GetComponentInParent<PrototypeShelf>();
        if (shelf != null)
        {
            activePrototype = shelf.GetPrototypeRoot(hitInfo.collider.transform);
        }

    }

    public void FinishDrawing()
    {
        if (!prototypeLibrary.ContainsKey(NextScale))
        {
            var newShelf = Instantiate(EmptyShelf);
            prototypeLibrary.Add(NextScale, newShelf);
            newShelf.transform.position = ShelfPosition;
            newShelf.gameObject.SetActive(false);
            newShelf.gameObject.name = $"Prototype Shelf {NextScale}";
        }

        prototypeLibrary[NextScale].AddPrototype(Table.GetDrawing());
        Table.StartNewDrawing();
    }

    public void CancelDrawing()
    {
        Table.Clear();
        Table.StartNewDrawing();
    }

    public void IncreaseScale()
    {
        if (!prototypeLibrary.ContainsKey(NextScale))
        {
            Debug.Log($"Scale {NextScale} not available");
            return;
        }
        
        prototypeLibrary[scale].Hide();
        Table.Clear();
        scale = NextScale;
        Table.SetScale(NextScale);
        Table.StartNewDrawing();
        prototypeLibrary[scale].Show();
        activePrototype = null;
        ScaleDisplay.text = $"{scale}";
    }

    public void ReduceScale()
    {
        if (!prototypeLibrary.ContainsKey(PreviousScale))
        {
            Debug.Log($"Scale {PreviousScale} not available");
            return;
        }

        prototypeLibrary[scale].Hide();
        Table.Clear();
        scale = PreviousScale;
        Table.SetScale(NextScale);
        Table.StartNewDrawing();
        prototypeLibrary[scale].Show();
        activePrototype = null;
        ScaleDisplay.text = $"{scale}";
    }

}
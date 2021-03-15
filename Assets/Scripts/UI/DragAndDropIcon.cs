using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// drag and drop 2d UI and instantiate 3d tower object on grid
public class DragAndDropIcon : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // References
    public Canvas canvasRef;
    public GameObject TargetTower;
    RectTransform rectTransform;
    SimpleToggleBoard SimpleToggleBoardRef;
    ResourceInventorySystem InventorySystemRef;
    TowerInfo TInfo;

    // Variables
    bool Available;
    Vector2 StartAnchoredPosition;
    bool isDragging;
    bool canbuild;

    void Start()
    {
        // set variables
        Available = true;


        // set references
        InventorySystemRef = GameObject.FindGameObjectWithTag("TowerManager").GetComponent<ResourceInventorySystem>();
        rectTransform = GetComponent<RectTransform>();
        SimpleToggleBoardRef = gameObject.transform.parent.GetComponent<SimpleToggleBoard>();
        TInfo = TargetTower.GetComponent<TowerInfo>();


        // set slot start position
        StartAnchoredPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // determine if resource is available for building
        canbuild = ResourceInventorySystem.bricks > TInfo.RequiredBricks
        && ResourceInventorySystem.gold > TInfo.RequiredGolds
        && ResourceInventorySystem.diamond > TInfo.RequiredDiamonds;

        if (canbuild)
        {
            Available = true;
        }
        else
        {
            Available = false;
        }

        //  set icon alpha
        if (Available)
        {
            if(isDragging)
            {
                SetIconDisable();
            }
            else
            {
                SetIconAvaliable();
            }
        }
        else
        {
            SetIconDisable();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // print(TInfo.RequiredBricks);
        // print(TInfo.RequiredGolds);
        // print(TInfo.RequiredDiamonds);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Available)
        {
            isDragging = true;

            // show the board
            SimpleToggleBoardRef.Toggle();
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // if resource is sufficient
        if (Available)
        {
            // set icon anchor position to cursor position
            rectTransform.anchoredPosition += eventData.delta / canvasRef.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Available)
        {
            print("Enddrag");

            // reset icon position
            rectTransform.anchoredPosition = StartAnchoredPosition;

            // determine witch cell to spawn tower
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                if (hit.transform != null && hit.transform.gameObject.tag == "Cell")
                {
                    // print("hit");
                    // print(hit.transform.gameObject.transform.position);
                    print(hit.transform.gameObject.tag);


                    // get cell
                    Cell cellRef = hit.transform.gameObject.GetComponent<Cell>();

                    // if no tower on the cell
                    if (cellRef.currentTower == null)
                    {

                        // spawn tower in the designated cell
                        Instantiate(TargetTower, new Vector3(cellRef.transform.position.x, 3.0f, cellRef.transform.position.z), TargetTower.transform.rotation);

                        // set that cell's tower to the tower spawned
                        cellRef.currentTower = TargetTower.GetComponent<Tower>();

                        // deduct resources from the inventory
                        DeductResources();
                    }
                }
            }
            isDragging = false;

            // hide the board
            SimpleToggleBoardRef.Toggle();


        }
    }

    // Set icon alpha
    void SetIconAvaliable()
    {
        GetComponent<Image>().color = new Color(
            GetComponent<Image>().color.r,
            GetComponent<Image>().color.g,
            GetComponent<Image>().color.b,
            1.0f
        );
    }

    void SetIconDisable()
    {
        GetComponent<Image>().color = new Color(
            GetComponent<Image>().color.r,
            GetComponent<Image>().color.g,
            GetComponent<Image>().color.b,
            0.5f
        );
    }

    // deduct resources from the inventory system
    void DeductResources()
    {
        ResourceInventorySystem.bricks -= TInfo.RequiredBricks;
        ResourceInventorySystem.gold -= TInfo.RequiredGolds;
        ResourceInventorySystem.diamond -= TInfo.RequiredDiamonds;
    }

}

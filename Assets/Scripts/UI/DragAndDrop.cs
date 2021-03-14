using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// drag and drop 2d UI and instantiate 3d tower object on grid
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // References
    public Canvas canvasRef;
    RectTransform rectTransform;
    TowerManager3 TManagerRef;
    SimpleToggleBoard SimpleToggleBoardRef;
    ResourceInventorySystem InventorySystemRef;





    // Variables
    public int TowerType;
    bool Available;
    Vector2 StartAnchoredPosition;
    bool isDragging;
    

    void Start()
    {
        // set variables
        Available = true;
        isDragging = false;
        
        // set references
        TManagerRef = GameObject.FindGameObjectWithTag("TowerManager").GetComponent<TowerManager3>();
        rectTransform = GetComponent<RectTransform>();
        SimpleToggleBoardRef = gameObject.transform.parent.GetComponent<SimpleToggleBoard>();

        // set slot start position
        StartAnchoredPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (Available)
        {
            SetIconAvaliable();
        }
        else
        {
            SetIconDisable();
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {   
        if (Available)
        {
            print("Startdrag");

            // show the board
            SimpleToggleBoardRef.Toggle();
        }
    }



    public void OnDrag(PointerEventData eventData)
    {
        // if resource is sufficient
        if (Available)
        {
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


}

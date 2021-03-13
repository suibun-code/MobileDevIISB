using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// drag and drop 2d UI and instantiate 3d tower object on grid
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvasRef;
    RectTransform rectTransform;
    TowerManager3 TMRef;
    ToggleBoard ToggleBoardRef;

    
    Vector2 StartAnchoredPosition;
    public int TowerType;
    bool isDragging;
    

    void Start()
    {
        isDragging = false;
        TMRef = GameObject.FindGameObjectWithTag("TowerManager").GetComponent<TowerManager3>();
        rectTransform = GetComponent<RectTransform>();
        StartAnchoredPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        

    }
    public void OnDrag(PointerEventData eventData)
    {
        

        rectTransform.anchoredPosition += eventData.delta / canvasRef.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = StartAnchoredPosition;

    }





}

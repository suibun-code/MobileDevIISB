using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Piece : EventTrigger
{
    public Color color = Color.clear;
    protected Space originalSpace = null; //The space the piece should be at when the game is reset, the original board.
    protected Space currentSpace = null; //The space the piece is currently residing at.
    protected RectTransform rectTransform = null;
    protected PieceManager pieceManager;
    protected Space targetSpace = null;
    protected Vector3Int movement = Vector3Int.one;
    protected List<Space> highlightedSpaces = new List<Space>(); //List of available spaces the piece can move to.

    public virtual void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        pieceManager = newPieceManager;

        color = newTeamColor;
        GetComponent<Image>().color = newSpriteColor;
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetSpace(Space newSpace)
    {
        currentSpace = newSpace;
        originalSpace = newSpace;
        currentSpace.currentPiece = this;

        transform.position = newSpace.transform.position;
        gameObject.SetActive(true);
    }

    public void Reset()
    {
        Kill();
        SetSpace(originalSpace);
    }

    public void Kill()
    {
        currentSpace.currentPiece = null;
        gameObject.SetActive(false);
    }

    private void CreateSpacePath(int xDir, int yDir, int movement)
    {
        int targX = currentSpace.boardPosition.x;
        int targY = currentSpace.boardPosition.y;

        for (int i = 1; i <= movement; i++)
        {
            targX += xDir;
            targY += yDir;

            //get the state of the target space.
            SpaceState spaceState = SpaceState.None;
            spaceState = currentSpace.board.ValidateSpace(targX, targY, this);

            if (spaceState == SpaceState.Enemy)
            {
                highlightedSpaces.Add(currentSpace.board.allSpaces[targX, targY]);
                break;
            }

            //if the cell is not free, break.
            if (spaceState != SpaceState.Free)
                break;

            //add to list
            highlightedSpaces.Add(currentSpace.board.allSpaces[targX, targY]);
        }
    }

    protected virtual void CheckPathing()
    {
        //horizontal
        CreateSpacePath(1, 0, movement.x);
        CreateSpacePath(-1, 0, movement.x);

        //vertical
        CreateSpacePath(0, 1, movement.y);
        CreateSpacePath(0, -1, movement.y);

        //upper diagonal
        CreateSpacePath(1, 1, movement.z);
        CreateSpacePath(-1, 1, movement.z);

        //lower diagonal
        CreateSpacePath(-1, -1, movement.z);
        CreateSpacePath(1, -1, movement.z);
    }

    protected void ShowSpaces()
    {
        foreach (Space space in highlightedSpaces)
        {
          space.mOutlineImage.enabled = true;
        } 
    }

    protected void ClearSpaces()
    {
        foreach (Space space in highlightedSpaces)
            space.mOutlineImage.enabled = false;

        highlightedSpaces.Clear();
    }

    protected virtual void Move()
    {
        targetSpace.RemovePiece();

        currentSpace.currentPiece = null;

        currentSpace = targetSpace;
        currentSpace.currentPiece = this;

        transform.position = currentSpace.transform.position;
        targetSpace = null;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        CheckPathing();
        ShowSpaces();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        rectTransform.position += (Vector3)eventData.delta;

        foreach (Space space in highlightedSpaces)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(space.rectTransform, Input.mousePosition))
            {
                //if the mouse is within the space of a valid space, move to it then break out of the foreach loop.
                targetSpace = space;
                break;
            }

            //if the mouse ISN'T within a valid space, do nothing.
            targetSpace = null;
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ClearSpaces();

        if (!targetSpace) //if no current space, set back to original space.
        {
            transform.position = currentSpace.gameObject.transform.position;
            return;
        }

        Move();

        pieceManager.SwitchSides(color);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

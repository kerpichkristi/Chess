using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    DragAndDrop dad;

    public Rules() {
        dad = new DragAndDrop();
    }
    void Start()
    {
       
    }

    void Update()
    {
        dad.Action();
    }



}

class DragAndDrop
{

    enum State
    {
        none,
        drag
    }

    State state;
    GameObject item;

    public DragAndDrop()
    {

        state = State.none;
        item = null;
    }

    public bool Action()
    {

        switch (state)
        {

            case State.none:
                if (IsMouseButtonPressed())
                    PickUp();
                break;
       /*     case State.drag:
                if (IsMouseButtonPressed())
                    Drag();
                else
                {
                    Drop();
                    return true;
                }
                break;*/
        }
        return false;
    }

    bool IsMouseButtonPressed()
    {
        return Input.GetMouseButton(0);
    }
    void PickUp()
    {

        Vector2 clickPosition = GetClickPosition();
        Transform clickedItem = GetItemAt(clickPosition);
        if (clickedItem == null) return;
        item = clickedItem.gameObject;
        state = State.drag;
        Debug.Log("picked up: " + item.name);
    }
    Vector2 GetClickPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Transform GetItemAt(Vector2 position)
    {
        RaycastHit2D[] figures = Physics2D.RaycastAll(position, position, 0.5f);
        if (figures.Length == 0)
            return null;
        return figures[0].transform;
    }

}

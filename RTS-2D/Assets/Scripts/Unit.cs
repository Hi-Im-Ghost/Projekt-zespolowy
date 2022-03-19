using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Unit : MonoBehaviour
{

    private SpriteRenderer sprRenderer;
    Vector2 endPoint;
    private GridController gridController;
    List<Point> path;
    void Start()
    {
        GameObject it = GameObject.Find("GridController");
        gridController = it.GetComponent<GridController>();
        
        Selection.Instance.unitList.Add(this.gameObject);
        endPoint = transform.position;
        sprRenderer = GetComponent<SpriteRenderer>();

        // create source and target points
        //Point _from = new Point(1, 1);
        //Point _to = new Point(10, 10);

        // get path
        // path will either be a list of Points (x, y), or an empty list if no path is found.
    }

    private void Update() {
        if(Vector2.Distance(transform.position,endPoint) >= 0.1){
            Vector3 newPosition; 
            newPosition.x = endPoint.x - transform.position.x;
            newPosition.y = endPoint.y - transform.position.y;
            newPosition.z = transform.position.z;
            newPosition /= 100;
            transform.position += newPosition; 
        }
    }
    private void OnDestroy()
    {
        Selection.Instance.unitList.Add(this.gameObject);
    }

    /*
     * Wykonywana gdy jednostka jest zaznaczana przez skrypt Selection
     */
    private void OnSelect()
    {
        sprRenderer.color = new Color(1f, 0f, 0f, 1f);
    }

    /*
     * Wykonywana gdy jednostka jest odznaczana przez skrypt Selection
     */
    private void OnDeselect()
    {
        sprRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    public void  CreatePath(Point _from,  Point _to,Vector2 mousePos){
        endPoint = mousePos;
        path = Pathfinding.FindPath(gridController.grid, _from, _to);
        foreach (var it in path)
        {
            Debug.Log(it.x);
        }
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar : MonoBehaviour
{
    private GameObject[][]      tabNodes = null;
    public  List<GameObject>    openList = new List<GameObject>();
    public  List<GameObject>    closedList = new List<GameObject>();
    public  bool                isNextToTarget;
    private bool                cantFind;
    private GameObject          returnNode;
    private int                 targetX;
    private int                 targetY;
    private int                 initialID;
    private int                 targetID;
    private int                 selfX;
    private int                 selfY;
    private GameObject          mapManager;
    private bool                targetFound = false;
    private int                 maxX;
    private int                 maxY;
    private int                 xTmp;
    private int                 yTmp;
    private int                 targetI;
    private bool                tabIsFilled = false;


    private void Start()
    {
        mapManager = GameObject.Find("MapManager");
        StartCoroutine(FillTab());
        isNextToTarget = false;
    }

    IEnumerator FillTab()
    {
        yield return new WaitForSeconds(0.1f);
        tabNodes = mapManager.GetComponent<MapManager>().GetTabNodes();

        if (tabNodes == null)
            StartCoroutine(FillTab());
        else
            tabIsFilled = true;
    }

    public Vector2 StartPathFinding(Vector2 targetPos)
    {
        if (tabIsFilled == false)
            return (targetPos);
        else
            return (FindPath(targetPos));
    }

    private Vector2 FindPath(Vector2 targetPos)
    {
        openList.Clear();
        closedList.Clear();
        targetFound = false;
        cantFind = false;

        FindTargetClosestNode(targetPos);

        SetHValue();
        closedList.Add(tabNodes[selfY][selfX].gameObject);
        xTmp = selfX;
        yTmp = selfY;

        while (targetFound == false)
        {
            FillOpenList(xTmp, yTmp);
            FillClosedList();
            if (cantFind == true)
                return (targetPos);
        }

        returnNode = closedList[targetI];


        if (returnNode.GetComponent<Node>().parent.GetComponent<Node>().id == initialID)
        {
            return (targetPos);
        }

        while (returnNode.GetComponent<Node>().parent.GetComponent<Node>().id != initialID)
        {
            returnNode = returnNode.GetComponent<Node>().parent;
        }

        return (new Vector2(returnNode.transform.position.x, returnNode.transform.position.y));
    }

    private void FillOpenList(int x, int y)
    {
        if (y > 0 &&
            tabNodes[y - 1][x].GetComponent<Node>().wall == false &&
            CanFillOpenList(x, y - 1) == true)
        {
            openList.Add(tabNodes[y - 1][x]);
            tabNodes[y - 1][x].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y - 1][x].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y - 1][x].GetComponent<Node>().F = tabNodes[y - 1][x].GetComponent<Node>().G + tabNodes[y - 1][x].GetComponent<Node>().H;
        }

        if (y > 0 &&
            x < maxX &&
            tabNodes[y - 1][x + 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x + 1, y - 1) == true)
        {
            openList.Add(tabNodes[y - 1][x + 1]);
            tabNodes[y - 1][x + 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y - 1][x + 1].GetComponent<Node>().G = 14 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y - 1][x + 1].GetComponent<Node>().F = tabNodes[y - 1][x + 1].GetComponent<Node>().G + tabNodes[y - 1][x + 1].GetComponent<Node>().H;
        }

        if (x < maxX &&
            tabNodes[y][x + 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x + 1, y) == true)
        {
            openList.Add(tabNodes[y][x + 1]);
            tabNodes[y][x + 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y][x + 1].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y][x + 1].GetComponent<Node>().F = tabNodes[y][x + 1].GetComponent<Node>().G + tabNodes[y][x + 1].GetComponent<Node>().H;
        }

        if (y < maxY &&
            x < maxX &&
            tabNodes[y + 1][x + 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x + 1, y + 1) == true)
        {

            openList.Add(tabNodes[y + 1][x + 1]);
            tabNodes[y + 1][x + 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y + 1][x + 1].GetComponent<Node>().G = 14 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y + 1][x + 1].GetComponent<Node>().F = tabNodes[y + 1][x + 1].GetComponent<Node>().G + tabNodes[y + 1][x + 1].GetComponent<Node>().H;
        }

        if (y < maxY &&
            tabNodes[y + 1][x].GetComponent<Node>().wall == false &&
            CanFillOpenList(x, y + 1) == true)
        {

            openList.Add(tabNodes[y + 1][x]);
            tabNodes[y + 1][x].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y + 1][x].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y + 1][x].GetComponent<Node>().F = tabNodes[y + 1][x].GetComponent<Node>().G + tabNodes[y + 1][x].GetComponent<Node>().H;
        }

        if (y < maxY &&
            x > 0 &&
            tabNodes[y + 1][x - 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x - 1, y + 1) == true)
        {

            openList.Add(tabNodes[y + 1][x - 1]);
            tabNodes[y + 1][x - 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y + 1][x - 1].GetComponent<Node>().G = 14 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y + 1][x - 1].GetComponent<Node>().F = tabNodes[y + 1][x - 1].GetComponent<Node>().G + tabNodes[y + 1][x - 1].GetComponent<Node>().H;
        }

        if (x > 0 &&
            tabNodes[y][x - 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x - 1, y) == true)
        {

            openList.Add(tabNodes[y][x - 1]);
            tabNodes[y][x - 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y][x - 1].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y][x - 1].GetComponent<Node>().F = tabNodes[y][x - 1].GetComponent<Node>().G + tabNodes[y][x - 1].GetComponent<Node>().H;
        }

        if (y > 0 &&
            x > 0 &&
            tabNodes[y - 1][x - 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x - 1, y - 1) == true)
        {

            openList.Add(tabNodes[y - 1][x - 1]);
            tabNodes[y - 1][x - 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y - 1][x - 1].GetComponent<Node>().G = 14 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y - 1][x - 1].GetComponent<Node>().F = tabNodes[y - 1][x - 1].GetComponent<Node>().G + tabNodes[y - 1][x - 1].GetComponent<Node>().H;
        }
    }

    private bool CanFillOpenList(int x, int y)
    {
        for (int i = 0; i < closedList.Count; i++)
        {
            if (closedList[i].GetComponent<Node>().id == tabNodes[y][x].GetComponent<Node>().id)
                return(false);
        }

        for (int j = 0; j < openList.Count; j++)
        {
            if (openList[j].GetComponent<Node>().id == tabNodes[y][x].GetComponent<Node>().id)
                return (false);
        }

        return (true);
    }

    private void FillClosedList()
    {
        int nodeTmp = 0;
        int nodeID = 0;
        int lowestF = 10000;

        if (openList.Count == 0)
        {
            cantFind = true;
            return;
        }

        for (int j = 0; j < openList.Count; j++)
        {
            if (j == 0 ||
                lowestF > openList[j].GetComponent<Node>().F)
            {
                nodeTmp = j;
                lowestF = openList[j].GetComponent<Node>().F;
                nodeID = openList[j].GetComponent<Node>().id;
            }
        }

        if (nodeID == targetID)
        {
            targetFound = true;
            closedList.Add(openList[nodeTmp]);
            for (int i = 0; i < closedList.Count; i++)
            {
                if (nodeID == closedList[i].GetComponent<Node>().id)
                    targetI = i;
            }
        }
        else
        {
            xTmp = openList[nodeTmp].GetComponent<Node>().x;
            yTmp = openList[nodeTmp].GetComponent<Node>().y;

            closedList.Add(openList[nodeTmp]);
            openList.RemoveAt(nodeTmp);
        }
    }

    private void FindTargetClosestNode(Vector2 targetPos)
    {
        targetID = -1;
        targetX = -100;
        targetY = -100;
        int x = 0;
        int y = 0;
        int i = 0;
        float distance = 0;
        float selfDistance = 0;
        float closestDistance = 10000;
        float selfClosestDistance = 10000;

        maxX = mapManager.GetComponent<MapManager>().tabNodesMaxX;
        maxY = mapManager.GetComponent<MapManager>().tabNodesMaxY;

        while (y <= maxY)
        {
            while (x <= maxX)
            {
                if (tabNodes[y][x].GetComponent<Node>().wall == false)
                {
                    tabNodes[y][x].GetComponent<Node>().parent = null;
                    tabNodes[y][x].GetComponent<Node>().H = 0;
                    tabNodes[y][x].GetComponent<Node>().G = 0;
                    tabNodes[y][x].GetComponent<Node>().F = 0;
                    tabNodes[y][x].GetComponent<Node>().x = x;
                    tabNodes[y][x].GetComponent<Node>().y = y;
                    tabNodes[y][x].GetComponent<Node>().id = i++;

                    distance = Vector2.Distance(tabNodes[y][x].transform.position, targetPos);
                    if (closestDistance > distance)
                    {
                        closestDistance = distance;
                        targetX = x;
                        targetY = y;
                        targetID = tabNodes[y][x].GetComponent<Node>().id;
                    }
                    selfDistance = Vector2.Distance(tabNodes[y][x].transform.position, transform.position);
                    if (selfDistance < selfClosestDistance)
                    {
                        selfClosestDistance = selfDistance;
                        selfX = x;
                        selfY = y;
                        initialID = tabNodes[y][x].GetComponent<Node>().id;
                    }
                }
                x++;
            }
            x = 0;
            y++;
        }
    }

    private void SetHValue()
    {
        int x = 0;
        int y = 0;
        int xDiff = 0;
        int yDiff = 0;

        while (y <= mapManager.GetComponent<MapManager>().tabNodesMaxY)
        {
            while (x <= mapManager.GetComponent<MapManager>().tabNodesMaxX)
            {
                if (tabNodes[y][x].GetComponent<Node>().wall == false)
                {
                    if (x > targetX)
                        xDiff = x - targetX;
                    else
                        xDiff = targetX - x;

                    if (y > targetY)
                        yDiff = y - targetY;
                    else
                        yDiff = targetY - y;

                    tabNodes[y][x].GetComponent<Node>().H = xDiff + yDiff;
                }
                x++;
            }
            x = 0;
            y++;
        }
    }
}

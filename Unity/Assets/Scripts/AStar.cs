using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar : MonoBehaviour
{
    private GameObject[][]      tabNodes = null;
    public List<GameObject>     openList = new List<GameObject>();
    public List<GameObject>     closedList = new List<GameObject>();
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

    private void Start()
    {
        mapManager = GameObject.Find("MapManager");
        tabNodes = mapManager.GetComponent<MapManager>().tabNodes;
    }

    public Vector2 StartPathFinding(Vector2 targetPos)
    {
        openList.Clear();
        closedList.Clear();

        FindTargetClosestNode(targetPos);

        print("before H");
        SetHValue();

        print("before closedListAdd ");
        closedList.Add(tabNodes[selfY][selfX].gameObject);

        xTmp = selfX;
        yTmp = selfY;

        print("before targetFound");
     /*   while (targetFound == false)
        {
            print("yo");
            FillOpenList(xTmp, yTmp);
            FillClosedList();
        }*/

        for (int j = 0; j < 120; j++)
        {
            print("fill");
            FillOpenList(xTmp, yTmp);
            FillClosedList();
        }

        print("before returnNode init ");
        GameObject returnNode = closedList[targetI];

        print("before returnNodeIF ");
        if (returnNode.GetComponent<Node>().parent.GetComponent<Node>().id == initialID)
            return (new Vector2(tabNodes[selfY][selfX].transform.position.x, tabNodes[selfY][selfX].transform.position.y));

        print("before returnNodeWhile ");
    /*    while (returnNode.GetComponent<Node>().parent.GetComponent<Node>().id != initialID)
        {
            returnNode = returnNode.GetComponent<Node>().parent;
        }*/



        print("before returnFinal ");

        return (new Vector2(returnNode.transform.position.x, returnNode.transform.position.y));
    }

    private void FillOpenList(int x, int y)
    {
        print("fillopenlist begin " + x + " , " + y);

        print("in1");
        if (y > 0 &&
            tabNodes[y - 1][x].GetComponent<Node>().wall == false &&
            CanFillOpenList(x, y - 1) == true)
        {
            openList.Add(tabNodes[y - 1][x]);
            tabNodes[y - 1][x].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y - 1][x].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y - 1][x].GetComponent<Node>().F = tabNodes[y - 1][x].GetComponent<Node>().G + tabNodes[y - 1][x].GetComponent<Node>().H;
        }

        print("in2");
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

        print("in3");
        if (x < maxX)
        {
            if (tabNodes[y][x + 1].GetComponent<Node>().wall == false)
            {
                print("in3 1");
                if (CanFillOpenList(x + 1, y) == true)
                {
                    print("in3 2");
                    openList.Add(tabNodes[y][x + 1]);
                    tabNodes[y][x + 1].GetComponent<Node>().parent = tabNodes[y][x];
                    tabNodes[y][x + 1].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
                    tabNodes[y][x + 1].GetComponent<Node>().F = tabNodes[y][x + 1].GetComponent<Node>().G + tabNodes[y][x + 1].GetComponent<Node>().H;
                }
            }
            print("in3 3");

        }

        print("in4");
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

        print("in5");
        if (y < maxY &&
            tabNodes[y + 1][x].GetComponent<Node>().wall == false &&
            CanFillOpenList(x, y + 1) == true)
        {

            openList.Add(tabNodes[y + 1][x]);
            tabNodes[y + 1][x].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y + 1][x].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y + 1][x].GetComponent<Node>().F = tabNodes[y + 1][x].GetComponent<Node>().G + tabNodes[y + 1][x].GetComponent<Node>().H;
        }

        print("in6");
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

        print("in7");
        if (x > 0 &&
            tabNodes[y][x - 1].GetComponent<Node>().wall == false &&
            CanFillOpenList(x - 1, y) == true)
        {

            openList.Add(tabNodes[y][x - 1]);
            tabNodes[y][x - 1].GetComponent<Node>().parent = tabNodes[y][x];
            tabNodes[y][x - 1].GetComponent<Node>().G = 10 + tabNodes[y][x].GetComponent<Node>().G;
            tabNodes[y][x - 1].GetComponent<Node>().F = tabNodes[y][x - 1].GetComponent<Node>().G + tabNodes[y][x - 1].GetComponent<Node>().H;
        }

        print("in8");
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
        print("fillopenlist end");
    }

    private bool CanFillOpenList(int x, int y)
    {
        print("canfillopenList");
        for (int i = 0; i < closedList.Count; i++)
        {
            if (closedList[i].GetComponent<Node>().id == tabNodes[y][x].GetComponent<Node>().id)
                return(false);
        }
        print("canfillopenList1");

        print("canfillopenList Count" + openList.Count);
        for (int j = 0; j < openList.Count; j++)
        {
            print("canfillopenList1.5, j : " + j);
            if (openList[j].GetComponent<Node>().id == tabNodes[y][x].GetComponent<Node>().id)
                return (false);
        }
        print("canfillopenList2");

        return (true);
    }

    private void FillClosedList()
    {
        print("fillclosedlist begin");
        int nodeTmp = 0;
        int nodeID = 0;
        int lowestF = 10000;

        for (int j = 0; j < openList.Count; j++)
        {
            if (j == 0 ||
                lowestF > openList[j].GetComponent<Node>().F)
            {
                print("node0");
                nodeTmp = j;
                lowestF = openList[j].GetComponent<Node>().F;
                nodeID = openList[j].GetComponent<Node>().id;
            }
        }

        print("fillclosedlist begin1");
        if (nodeID == targetID)
        {
            print("fillclosedlist begin2");
            targetFound = true;
            closedList.Add(openList[nodeTmp]);
            for (int i = 0; i < closedList.Count; i++)
            {
                if (nodeID > closedList[i].GetComponent<Node>().id)
                    targetI = i;
            }
        }
        else
        {
            print("fillclosedlist begin3");
            print("nodeTmp = " + nodeTmp);
            print("nodeID = " + nodeID);
            for (int t = 0; t < openList.Count; t++)
            {
                print("node");
            }
            xTmp = openList[nodeTmp].GetComponent<Node>().x;
            yTmp = openList[nodeTmp].GetComponent<Node>().y;

            print("fillclosedlist begin4");
            closedList.Add(openList[nodeTmp]);
            print("fillclosedlist begin5");
            openList.RemoveAt(nodeTmp);
        }
        print("fillclosedlist end");
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
        float closestDistance = 10000;
        maxX = mapManager.GetComponent<MapManager>().tabNodesMaxX;
        maxY = mapManager.GetComponent<MapManager>().tabNodesMaxY;

        while (y <= maxY)
        {
            while (x <= maxX)
            {
                if (Vector2.Distance(tabNodes[y][x].transform.position, transform.position) < 0.05f)
                {
                    selfX = x;
                    selfY = y;
                    initialID = tabNodes[y][x].GetComponent<Node>().id;
                }
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

                    //print("nom : " + tabNodes[y][x].name + "|x : " + x + "|xTarget : " + targetX + "|yTarget : " + targetY + "|y : " + y + "|xDiff : " + xDiff + "| yDiff : " + yDiff + "| H : " + (xDiff + yDiff));
                }
                x++;
            }
            x = 0;
            y++;
        }
    }
}

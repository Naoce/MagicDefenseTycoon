using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public  int         H;
    public  int         G;
    public  int         F;
    public  int         x;
    public  int         y;
    public  bool        wall;
    public  GameObject  parent;
    public  int         id;
}

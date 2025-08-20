using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCell : MonoBehaviour
{
    //自身坐标
    public Vector2Int coordinates { get; set; }
    //其中的数字瓦片
    public Tile tile { get; set; }

    //判断是否瓦片为空
    public bool empty => tile == null;
    
    public bool occupied => tile != null;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Player thePlayer;

    void Start () {

        //在游戏运行时，首先遍历一遍PlayerController脚本
        Player thePlayer = FindObjectOfType<Player>();

    }
    
    // Update is called once per frame
    void Update () {
        
    }


    /// 调用方法Respawn开启携程方法RespawnCo，完成等待复活事件
    public void Respawn()
    {
        //开启携程RespawnCo
        StartCoroutine("RespawnCo");
        
    }


    /// <summary>
    /// 携程，等待X秒后复活角色
    /// </summary>
    /// <returns></returns>
    public IEnumerator RespawnCo()
    {
        
        //隐藏角色
        thePlayer.gameObject.SetActive(false);
        //等待X秒后执行
        
        yield return new WaitForSeconds(2);
        //把复活碰撞点的位置传给角色，让角色在复活碰撞点复活
        
        thePlayer.transform.position = thePlayer.RespawnPosition;
        //显示角色
        
        thePlayer.gameObject.SetActive(true);
    }

}
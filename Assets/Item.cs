using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public enum ItemType
{
    Hoe
}
public class Item : MonoBehaviour
{
    public ItemType type;
    GameObject obj;
    Vector3 pos;
    bool flag=false;
    public void Interaction()
    {
        if(type == ItemType.Hoe)
        {
            pos = transform.position;
            Invoke("SuspendingExecution", 0);
            Invoke("SuspendingExecution", 3.0f);
            pos.z+=1;
            transform.position = pos;
        }
    }
    void SuspendingExecution()
    {
        flag = !flag;
        GetComponentInParent<Animator>().SetBool("IsUsing", flag);
    }
}

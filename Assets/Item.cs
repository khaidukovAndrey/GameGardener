using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public enum ItemType
{
    Hoe,
    WateringCan,
    Seeds
}
public class Item : MonoBehaviour
{
    public ItemType type;
    bool flag=false;
    public void Interaction()
    {
        if(type == ItemType.Hoe)
        {
            Invoke("SuspendingExecution", 0);
            Invoke("SuspendingExecution", 3.0f);
        }
    }
    void SuspendingExecution()
    {
        flag = !flag;
        GetComponent<Animator>().SetBool("IsUsing", flag);
    }
}

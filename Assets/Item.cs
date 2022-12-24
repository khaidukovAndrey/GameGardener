using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public enum ItemType
{
    Hoe,
    WateringCan,
    Seeds,
    MiniHoe,
    None
}
public class Item : MonoBehaviour
{
    public ItemType type;
    bool flag = false;
    public void Interaction()
    {
        if (type == ItemType.WateringCan)
        {
            Invoke("SuspendingExecutionWCan", 0);
            Invoke("SuspendingExecutionWCan", 3.0f);
        }
        else if (type == ItemType.Seeds)
        {
            Invoke("SuspendingExecutionSeeds", 0);
            Invoke("SuspendingExecutionSeeds", 3.0f);
        }
        else if (type == ItemType.None)
        {
        }
        else
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
    void SuspendingExecutionWCan()
    {
        flag = !flag;
        GetComponent<Animator>().SetBool("IsUsing", flag);
        GetComponentInChildren<ParticleSystem>().Play();
    }
    void SuspendingExecutionSeeds()
    {
        flag = !flag;
        GetComponent<Animator>().SetBool("IsUsing", flag);
    }
}

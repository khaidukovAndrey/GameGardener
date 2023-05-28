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
            GetComponentInParent<AudioSource>().Play();
            Invoke("SuspendingExecutionWCan", 0);
            Invoke("SuspendingExecutionWCan", 2.9f);
        }
        else if (type == ItemType.Seeds)
        {
            GetComponentInParent<AudioSource>().Play();
            Invoke("SuspendingExecutionSeeds", 0);
            Invoke("SuspendingExecutionSeeds", 2.9f);
        }
        else if (type == ItemType.None)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponentInParent<AudioSource>().Play();
            Invoke("SuspendingExecution", 0);
            Invoke("SuspendingExecution", 2.9f);
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

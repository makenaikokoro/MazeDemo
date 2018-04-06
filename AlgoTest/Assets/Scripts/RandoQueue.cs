using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQueue <E> {

    protected List<E> queue = new List<E>();

    public void RandomAdd(E e)
    {
        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            queue.Insert(0, e);
        }
        else
        {
            queue.Add(e);
        }
    }

    public E RandomRemove()
    {
        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            E temp = queue[0];
            queue.RemoveAt(0);
            return temp;

        }
        else
        {
            E temp = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            return temp;

        }
    }

    public int size()
    {
        return queue.Count;
    }

    public bool isEmpty()
    {
        return queue.Count == 0 ? true : false;
    }
        
}

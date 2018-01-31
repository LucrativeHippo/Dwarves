using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueDirectAccess<T> {

    private T[] queue;
    private int start;
    private int end;
    private int size;

    public T this[int i]
    {
        get
        {
            if (i > size - 1 || i < 0)
            {
                Debug.LogError("Error: Attempted to get index of direct access " +
                    "queue with index that doesn't exist. " +
                    "Setting index to 0 to attempt recover.");
                i = 0;
            }
            int index = (i + start) % queue.Length;
            return queue[index];
        }
        set
        {
            if (i > size - 1 || i < 0)
            {
                Debug.LogError("Error: Attempted to set index of direct access " +
                    "queue with index that doesn't exist. " +
                    "Setting index to 0 to attempt recover.");
                i = 0;
            }
            int index = (i + start) % queue.Length;
            queue[index] = value;
        }
    }

    public QueueDirectAccess() {
        queue = new T[1];
        start = 0;
        end = 0;
        size = 0;
    }

    public bool isEmpty()
    {
        return size == 0;
    }

    public void enqueue(T input)
    {
        if (isEmpty())
        {
            start = 0;
            end = 0;
            queue[0] = input;
        }
        else
        {
            end++;
            if (end == queue.Length)
            {
                end = 0;
            }

            if (start == end)
            {
                doubleQueueSize();
            }

            queue[end] = input;
        }

        size++;
    }

    public T dequeue()
    {
        if (isEmpty())
        {
            return default(T);
        }
        else
        {
            T output = queue[start];
            start++;
            if (start == queue.Length)
            {
                start = 0;
            }

            size--;
            if (size < queue.Length / 2 && size > 1)
            {
                resize(queue.Length / 2);
            }
            return output;
        }
    }

    // This method will discard any values that don't fit.
    // So if you have a queue with 10 items and resize to 5,
    // it will simply discard the last 5 in the queue.
    //
    // Use at your own risk.
    public void resize(int newSize)
    {
        if (newSize < 1)
        {
            return;
        }

        T[] oldQueue = queue;
        queue = new T[newSize];

        for (int i = 0; i < newSize && i < size; i++)
        {
            queue[i] = oldQueue[start + i];
        }
    }

    private void doubleQueueSize()
    {
        resize(queue.Length * 2);
    }
}

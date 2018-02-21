using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathmanage : MonoBehaviour {
    Queue<pathrequest> pathqueue = new Queue<pathrequest>();
    pathrequest current;
    static pathmanage instance;
    Pathfinding pathfinding;
    bool isprocesspath;


    void Awake(){
        instance = this;

        pathfinding = GetComponent<Pathfinding>();

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void request(Vector3 start,Vector3 end,Action<Vector3[],bool> callback ){

        pathrequest newone = new pathrequest(start, end, callback);
        instance.pathqueue.Enqueue(newone);
        instance.next();


    }


    void next()
    {
        //end at e05 6:17 on youtube video
        if (!isprocesspath && pathqueue.Count > 0)
        {
            current = pathqueue.Dequeue();
            isprocesspath = true;
            pathfinding.startfindpath(current.start, current.end);
            //create startfindpath
        }
    }

        public void finishpath(Vector3[] path, bool sucess){
        current.callback(path, sucess);
        isprocesspath = false;
        next();
        }








    struct pathrequest{
        public Vector3 start;
        public Vector3 end;
        public Action<Vector3[], bool> callback;

        public pathrequest(Vector3 positionstart,Vector3 positionend,Action<Vector3[], bool> pcallback){
            start = positionstart;
            end = positionend;
            callback = pcallback;


        }

    }


}

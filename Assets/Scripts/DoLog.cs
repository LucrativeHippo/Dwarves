using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

public class DoLog : MonoBehaviour {
	private static string kTAG = "PCGame";
	public Logger myLogger;

	void Awake()
	{
		Directory.CreateDirectory (Application.persistentDataPath+"/gameLogs");
		Directory.CreateDirectory (Application.persistentDataPath+"/gameLogs/errorLogs");
		Directory.CreateDirectory (Application.persistentDataPath+"/gameLogs/genLogs");
		myLogger = new Logger(new GameLogger());
		myLogger.Log(kTAG, "Log Start: "+ System.DateTime.Now);
		myLogger.LogWarning (kTAG, "GenLogStart");
		myLogger.LogError (kTAG, "ErrorLogStart");

	}
}


public class GameLogger : ILogHandler {
	private FileStream fileStreamMain, fileStreamError, fileStreamGen;
	private StreamWriter streamWriterMain, streamWriterError, streamWriterGen;
	private ILogHandler defaultLogHandler = Debug.unityLogger.logHandler;

	public GameLogger(){
		string filePathMain = Application.persistentDataPath + "/gameLogs/mainLog"+System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")+".txt";
		string filePathError = Application.persistentDataPath + "/gameLogs/errorLogs/errLog"+System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")+".txt";
		string filePathGem = Application.persistentDataPath + "/gameLogs/genLogs/genLog"+System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")+".txt";


		fileStreamMain = new FileStream(filePathMain, FileMode.OpenOrCreate, FileAccess.Write);
		fileStreamError = new FileStream(filePathError, FileMode.OpenOrCreate, FileAccess.Write);
		fileStreamGen = new FileStream(filePathGem, FileMode.OpenOrCreate, FileAccess.Write);


		streamWriterMain = new StreamWriter(fileStreamMain);
		streamWriterError = new StreamWriter(fileStreamError);
		streamWriterGen = new StreamWriter(fileStreamGen);



		Debug.unityLogger.logHandler = this; //Replaces default debug log handler
	}

	public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
	{
		if(logType.Equals(LogType.Error)){
			streamWriterError.WriteLine (String.Format (format, args));
			streamWriterError.Flush ();
		}
		else if(logType.Equals(LogType.Warning)){
			streamWriterGen.WriteLine (String.Format (format, args));
			streamWriterGen.Flush ();
		}else{
			streamWriterMain.WriteLine (String.Format (format, args));
			streamWriterMain.Flush ();
		}

		defaultLogHandler.LogFormat (logType, context, format, args);
	}

	public void LogException(Exception exception, UnityEngine.Object context)
	{
		defaultLogHandler.LogException (exception, context);
	}
}


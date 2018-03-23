using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBellListener {


	/// <summary>
	/// Notifies all listeners whether it is safe or not
	/// NPC will either hide or become a guard based on it's braveness when not safe
	/// </summary>
	/// <param name="safe"></param>
	void bellRang(bool safe);
	
	/// <summary>
	/// Calls bellRang with a forced flee. NPC will run and hide regardless of braveness
	/// </summary>
	/// <param name="hide">Whether NPC hides or reverts to daily life</param>
	void forceBell(bool hide);
}

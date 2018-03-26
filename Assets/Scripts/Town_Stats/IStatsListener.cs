using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatsListener {
	void publish(Global_Stats stats);
}

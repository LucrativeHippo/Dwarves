using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthListener {
	void setHealth(Health health);

	void publish();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCListener {
	void setNPCList(OwnedNPCList list);
	void publish();
}

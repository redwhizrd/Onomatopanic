using UnityEngine;
using System.Collections;

public interface Effect{

	bool shouldPush(Fighter owner, Fighter opposition);
	void reset();
}


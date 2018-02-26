using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitDict<K,V> {

	Dictionary<K,V> traitValues;
	V defaultReturn;

	/// <summary>
	/// Initializes a new instance of the <see cref="TraitDict`2"/> class.
	/// </summary>
	/// <param name="size">Size of dictionary.</param>
	/// <param name="defReturn">Default return value.</param>
	public TraitDict(int size, V defReturn){
		traitValues = new Dictionary<K,V> (size);
		defaultReturn = defReturn;
	}


	public V getValue(K s){
		if (traitValues.ContainsKey (s))
			return traitValues [s];
		else
			return defaultReturn;
	}

	public void setValue(K s, V newVal){
		traitValues [s] = newVal;
	}

	public bool ContainsKey(K k){
		return traitValues.ContainsKey (k);
	}

	public Dictionary<K,V> getDict(){
		return traitValues;
	}

}

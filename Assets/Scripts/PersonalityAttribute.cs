using UnityEngine;

public class PersonalityAttribute : PropertyAttribute {

	public readonly string[] names;
    public PersonalityAttribute(string[] names) { this.names = names; }
}

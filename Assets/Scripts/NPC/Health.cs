using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health {
	/// The health.
	int health;
	int maxHealth;


	public Health(int startHealth){
		health = maxHealth = startHealth;

	}
		

	/// <summary>
	/// Damage the character. Returns true if character is dead.
	/// </summary>
	/// <param name="dmg">Damage to deal.</param>
	/// <returns>True if health less than 0, false otherwise.</returns>
	/// <exception cref="UnityException">Throws if dmg is less than 0.</exception>
	public bool damage(int dmg){
		if (dmg < 0)
			throw new UnityException ("You can't heal from damage!");
		
		health -= dmg;
		if (health <= 0) {
			return true;
		}
		return false;
	}

	/// <summary>
	/// Heal the character. Only heals up to max health.
	/// </summary>
	/// <param name="heal">Amount to heal.</param>
	/// <exception cref="UnityException">Throws if heal is less than 0.</exception>
	public void heal(int heal){
		if (heal < 0)
			throw new UnityException ("You can't damage from heal!");
		
		if (heal + health > maxHealth) {
			health = maxHealth;
		} else {
			health += heal;
		}
	}
}

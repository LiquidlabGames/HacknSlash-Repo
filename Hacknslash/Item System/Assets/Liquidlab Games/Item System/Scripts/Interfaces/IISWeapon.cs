using UnityEngine;
using System.Collections;

namespace LiquidlabGames.ItemSystem {
	public interface IISWeapon {
		int MinDamage { get; set; }
		int Attack();
	}
}

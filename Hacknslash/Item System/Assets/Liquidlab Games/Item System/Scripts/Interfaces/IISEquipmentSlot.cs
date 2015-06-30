using UnityEngine;
using System.Collections;

namespace LiquidlabGames.ItemSystem {
	public interface IISEquipmentSlot {
		string Name { get; set; }
		Sprite Icon { get; set; }
	}
}

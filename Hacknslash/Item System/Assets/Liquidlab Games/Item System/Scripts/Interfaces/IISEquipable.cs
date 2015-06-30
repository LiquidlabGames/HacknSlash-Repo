using UnityEngine;
using System.Collections;

namespace LiquidlabGames.ItemSystem {
	public interface IISEquipable {
		ISEquipmentSlot EquipmentSlot { get; }
		bool Equip();
	}
}

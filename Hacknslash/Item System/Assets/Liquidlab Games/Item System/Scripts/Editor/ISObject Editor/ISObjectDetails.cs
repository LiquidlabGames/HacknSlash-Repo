using UnityEngine;
using UnityEditor;
using System.Collections;

namespace LiquidlabGames.ItemSystem.Editor {
	public partial class ISObjectEditor {
		enum DisplayState {
			NONE,
			DETAILS
		}
		ISWeapon tempWeapon = new ISWeapon();

		bool ShowNewWeaponDetails = false;

		DisplayState state = DisplayState.NONE;

		void ItemDetails() {
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			switch(state) {
			case DisplayState.DETAILS:
				if (ShowNewWeaponDetails)
					DisplayNewWeapon();
				break;
			default:
				break;
			}

			GUILayout.EndVertical();

			GUILayout.Space(50);
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayButtons();
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		}

		void DisplayNewWeapon() {
			tempWeapon.OnGUI();
		}

		void DisplayButtons() {
			if (!ShowNewWeaponDetails) {
				if (GUILayout.Button("Create Weapon")) {
					tempWeapon = new ISWeapon();
					ShowNewWeaponDetails = true;
					state = DisplayState.DETAILS;
				}
			}
			else {
				GUI.SetNextControlName("SaveButton");
				if (GUILayout.Button("Save")) {
					if(_selectedIndex == -1)
						database.Add(tempWeapon);
					else
						database.Replace(_selectedIndex, tempWeapon);

					ShowNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
					GUI.FocusControl("SaveButton");
				}

				if(_selectedIndex != -1) {
					if (GUILayout.Button("Delete")) {

						if (EditorUtility.DisplayDialog("Delete Weapon",
						                                "Are you sure that you want to delete " + database.Get(_selectedIndex).Name + " from the database?", 
						                                "Delete", 
						                                "Cancel")) {

							database.Remove(_selectedIndex);

							ShowNewWeaponDetails = false;
							tempWeapon = null;
							_selectedIndex = -1;
							state = DisplayState.NONE;

							GUI.FocusControl("DeleteButton");
						}
					}
				}
				
				if (GUILayout.Button("Cancel")) {
					ShowNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
					GUI.FocusControl("CancelButton");
				}
			}
		}
	}
}

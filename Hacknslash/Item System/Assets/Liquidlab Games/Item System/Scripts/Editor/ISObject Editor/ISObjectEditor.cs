using UnityEditor;
using UnityEngine;
using System.Collections;

namespace LiquidlabGames.ItemSystem.Editor {
	public partial class ISObjectEditor : EditorWindow {
		ISWeaponDatabase database;
		//		ISQuality selectedItem;
		
		const string DATABASE_NAME = @"llgWeaponDatabase.asset";
		const string DATABASE_PATH = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/"+ DATABASE_PATH +"/" + DATABASE_NAME;


		[MenuItem("LLG/Database/Item System Editor %#i")]
		public static void Init() {
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
			window.minSize = new Vector2(800,600);
			window.titleContent.text = "Item System";
			window.Show();
		}

		void OnEnable() {
			if (database == null)
				database = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);
		}

		void OnGUI() {
			TopTabBar();

			GUILayout.BeginHorizontal();
			ListView();
			ItemDetails();
			GUILayout.EndHorizontal();

			BottomStatusBar();
		}
	}
}

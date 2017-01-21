#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace LostInBardo
{
	public class WeakGameObjectDrawer
	{
		public static void OnGUI(string lable, ref WeakGameObject weakObj, Type type)
		{
			GUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(lable, weakObj.Name);
			var obj = EditorGUILayout.ObjectField(weakObj.GameObject, type, true) as GameObject;
			if(obj != null && obj.name != weakObj.Name) weakObj = new WeakGameObject(obj);
			if (GUILayout.Button("X", GUILayout.Width(30))) weakObj.Remove();
			GUILayout.EndHorizontal();
		}
	}
}
#endif
using System;
using System.Linq;
using UnityEngine;

namespace LostInBardo
{
	[Serializable]
	public struct WeakGameObject
	{
		[SerializeField] private GameObject _cachedGameObject;
		[SerializeField] private string _cachedName;
		[SerializeField] private string _cachedScene;

		public string Name { get { return _cachedName; } }
		public string Scene { get { return _cachedScene; } }

		public GameObject GameObject
		{
			get
			{
				if (string.IsNullOrEmpty(_cachedName)) return null;
				if (_cachedGameObject != null) return _cachedGameObject;
				var cachedName = _cachedName;
				var foundObj = Resources.FindObjectsOfTypeAll<Transform>().FirstOrDefault(transform => 
					!string.IsNullOrEmpty(transform.gameObject.scene.name) && transform.name == cachedName);
				if (foundObj == null) return null;
				_cachedGameObject = foundObj.gameObject;
				return _cachedGameObject;
			}
		}

		public bool IsNull { get { return string.IsNullOrEmpty(_cachedName); } }

		public WeakGameObject(GameObject gameObject)
		{
			_cachedGameObject = gameObject;
			_cachedScene = gameObject.scene.name;
			_cachedName = gameObject.name;
		}

		public void Remove()
		{
			_cachedGameObject = null;
			_cachedName = _cachedScene = string.Empty;
		}
	}
}

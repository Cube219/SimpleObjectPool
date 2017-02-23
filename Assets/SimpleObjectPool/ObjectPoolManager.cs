using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cube219.SimpleObjectPool
{
	/// <summary>
	/// Manage ObjectPools.
	/// </summary>
	public class ObjectPoolManager
	{
		private static List<ObjectPool> pools_ = new List<ObjectPool>();

		/// <summary>
		/// Get the ObjectPool that manages such type.
		/// </summary>
		/// <summary xml:lang="ko">
		/// </summary>
		/// <param name="pooledObjectType">Type that the ObjectPool managed.</param>
		/// <returns>A ObjectPool that manages that type.</returns>
		public static ObjectPool GetPool(Type pooledObjectType)
		{
			ObjectPool pool = pools_.Find(m => m.managedType == pooledObjectType);

			if (pool == null)
			{
				GameObject pool_gameObject = new GameObject(pooledObjectType.Name + " ObjectPool", typeof(ObjectPool));

				pool = pool_gameObject.GetComponent<ObjectPool>();
				pool.Initialize(pooledObjectType);
			}

			return pool;
		}
	}
}

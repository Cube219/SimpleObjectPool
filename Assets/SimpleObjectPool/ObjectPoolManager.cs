using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cube219.SimpleObjectPool
{
	/// <summary>
	/// Manage ObjectPools.
	/// (ObjectPool들을 관리합니다.)
	/// </summary>
	public class ObjectPoolManager
	{
		private static List<ObjectPool> pools_ = new List<ObjectPool>();

		/// <summary>
		/// Get the ObjectPool that manages such type.
		/// (해당 타입을 관리하는 ObjectPool을 가져옵니다.)
		/// </summary>
		/// <param name="pooledObjectType">Type that the ObjectPool managed. (ObjectPool이 관리하는 타입입니다.)</param>
		/// <returns>A ObjectPool that manages that type. (해당 타입을 관리하는 ObjectPool입니다.)</returns>
		public static ObjectPool GetPool(PooledObject pooledObject)
		{
			ObjectPool pool = pools_.Find(m => m.managedType == pooledObject.GetType());

			if (pool == null)
			{
				GameObject pool_gameObject = new GameObject(pooledObject.GetType().Name + " ObjectPool", typeof(ObjectPool));

				pool = pool_gameObject.GetComponent<ObjectPool>();
				pool.Initialize(pooledObject);

				pools_.Add(pool);
			}

			return pool;
		}
	}
}

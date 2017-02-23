using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cube219.SimpleObjectPool
{
	/// <summary>
	/// Collect and manage the objects that can be recycled.
	/// (재사용 가능한 object들을 모으고 관리합니다.)
	/// </summary>
	public class ObjectPool:MonoBehaviour
	{
		private PooledObject managedObject_;
		public Type managedType { get { return managedObject_.GetType(); } }

		private List<PooledObject> pooledObjects_ = new List<PooledObject>();

		/// <summary>
		/// Initialize ObjectPool.
		/// (ObjectPool을 초기화합니다.)
		/// </summary>
		/// <param name="managedObject">The Object managed by this ObjectPool. (이 ObjectPool이 관리할 Object입니다.)</param>
		public void Initialize(PooledObject managedObject)
		{
			managedObject_ = managedObject;
		}

		/// <summary>
		/// Get an Object.
		/// (Object를 가져옵니다.)
		/// </summary>
		public PooledObject GetObject()
		{
			PooledObject obj = pooledObjects_.Find(o => o.enabled == false);

			if (obj == null)
				obj = CreateNewObject();
			else
				obj.enabled = true;

			return obj;
		}

		/// <summary>
		/// Disable this Object. (해당 Object를 비활성화 시킵니다.)
		/// </summary>
		/// <param name="obj">The object that will be disabled. (비활성화할 Object입니다.)</param>
		/// <param name="delay">Delay before disable. (비활성화 되기 전 딜레이입니다.)</param>
		public void DisableObject(PooledObject obj, float delay)
		{
			pooledObjects_.Find(o => o.Equals(obj)).enabled = false;
		}

		/// <summary>
		/// Create a new Object.
		/// (새로운 Object를 만듭니다.)
		/// </summary>
		private PooledObject CreateNewObject()
		{
			PooledObject createdObj = Instantiate(managedObject_);
			createdObj.transform.parent = this.transform;

			pooledObjects_.Add(createdObj);
			return createdObj;
		}
	}
}

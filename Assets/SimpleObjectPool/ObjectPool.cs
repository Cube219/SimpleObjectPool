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
		private Type managedType_;
		public Type managedType { get { return managedType_; } }

		private PooledObject managedObject_;

		private List<PooledObject> pooledObjects_ = new List<PooledObject>();

		public void Initialize(PooledObject managedObject)
		{
			managedObject_ = managedObject;
			managedType_ = managedObject.GetType();
		}

		public PooledObject GetObject()
		{
			PooledObject obj = pooledObjects_.Find(o => o.enabled == false);

			if (obj == null)
				obj = CreateNewObject();
			else
				obj.enabled = true;

			return obj;
		}

		public void DisableObject(PooledObject obj, float delay)
		{
			pooledObjects_.Find(o => o.Equals(obj)).enabled = false;
		}

		private PooledObject CreateNewObject()
		{
			PooledObject createdObj = Instantiate(managedObject_);
			createdObj.transform.parent = this.transform;

			pooledObjects_.Add(createdObj);
			return createdObj;
		}
	}
}

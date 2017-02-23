using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cube219.SimpleObjectPool
{
	/// <summary>
	/// 
	/// </summary>
	public class ObjectPool:MonoBehaviour
	{
		private Type managedType_;
		public Type managedType { get { return managedType_; } }

		private List<PooledObject> poolObjects_;

		public void Initialize(Type managedType)
		{
			managedType_ = managedType;
		}
	}
}

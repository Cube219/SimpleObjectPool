using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cube219.SimpleObjectPool
{
	public class ObjectPoolManager:MonoBehaviour
	{
		private Type managedType_;
		public Type managedType { get { return managedType_; } }

		private List<PoolObject> poolObjects_;
	}
}

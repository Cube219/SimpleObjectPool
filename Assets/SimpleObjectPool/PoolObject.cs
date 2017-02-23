using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cube219.SimpleObjectPool
{
	public class PoolObject : MonoBehaviour
	{
		public static PoolObject Instantiate(PoolObject original)
		{
			return PoolObject.Instantiate(original, Vector3.zero, Quaternion.identity, null);
		}
		public static PoolObject Instantiate(PoolObject original, Transform parent)
		{
			return PoolObject.Instantiate(original, Vector3.zero, Quaternion.identity, parent);
		}
		public static PoolObject Instantiate(PoolObject original, Vector3 position, Quaternion rotation)
		{
			return PoolObject.Instantiate(original, position, rotation, null);
		}
		public static PoolObject Instantiate(PoolObject original, Vector3 position, Quaternion rotation, Transform parent)
		{
			return null;
		}
	}

	public static class ExtendMethodInPoolObject
	{
		public static void Instantiate2(this Object target)
		{
		}
	}
}
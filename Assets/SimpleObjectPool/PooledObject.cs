using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cube219.SimpleObjectPool
{
	/// <summary>
	/// Object that can be managed by ObjectPool.
	/// </summary>
	public class PooledObject : MonoBehaviour
	{
		public static PooledObject Instantiate(PooledObject original)
		{
			return PooledObject.Instantiate(original, Vector3.zero, Quaternion.identity, null);
		}
		public static PooledObject Instantiate(PooledObject original, Transform parent)
		{
			return PooledObject.Instantiate(original, Vector3.zero, Quaternion.identity, parent);
		}
		public static PooledObject Instantiate(PooledObject original, Vector3 position, Quaternion rotation)
		{
			return PooledObject.Instantiate(original, position, rotation, null);
		}
		public static PooledObject Instantiate(PooledObject original, Vector3 position, Quaternion rotation, Transform parent)
		{
			return null;
		}

		public static void Destroy(PooledObject obj)
		{
			Destroy(obj, 0f);
		}
		public static void Destroy(PooledObject obj, float delay = 0f)
		{
		}
	}

	// 테스트 코드... (Testing Code...)
	public static class ExtendMethodInPoolObject
	{
		public static void Instantiate2(this Object target)
		{
		}
	}
}

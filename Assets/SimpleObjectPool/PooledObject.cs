using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cube219.SimpleObjectPool
{
	/// <summary>
	/// An Object that can be recycled.
	/// It can be managed by ObjectPool.
	/// (재사용 가능한 Object입니다.
	/// ObjectPool에 의해 관리됩니다.)
	/// </summary>
	public abstract class PooledObject : MonoBehaviour
	{
		public new bool enabled
		{
			get { return base.gameObject.activeSelf; }
			set
			{
				if (value == true)
				{
					base.gameObject.SetActive(true);
					StartCoroutine(EnableLogic());
				}
				else
				{
					base.gameObject.SetActive(false);
					this.Invoke("OnDestroy", 0f);
				}
			}
		}
		private IEnumerator EnableLogic()
		{
			this.Invoke("Awake", 0f);
			yield return null;
			this.Invoke("Start", 0f);
		}

		////////////////////////////////////////////////////
		///// Instantiate and Destory for PooledObject /////
		///// (PooledObject전용 Instantiate와 Destory)  /////
		////////////////////////////////////////////////////
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
			ObjectPool pool = ObjectPoolManager.GetPool(original);
			PooledObject obj = pool.GetObject();

			return obj;
		}

		public static void Destroy(PooledObject obj)
		{
			Destroy(obj, 0f);
		}
		public static void Destroy(PooledObject obj, float delay = 0f)
		{
			ObjectPool pool = ObjectPoolManager.GetPool(obj);
			pool.DisableObject(obj, delay);
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

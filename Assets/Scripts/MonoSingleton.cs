using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object lockObject = new object();
    private static T instance = null;
    private static bool IsQuitting = false;

    public static T Instance
    {
        // ������ ����ȭ - Thread-Safe
        get
        {
            // �ѹ��� �� �����常 lock�� ����
            lock (lockObject)
            {
                // ��Ȱ��ȭ �ƴٸ� ������ ����ΰ� ���� �����.
                if (IsQuitting)
                {
                    return null;
                }

                // instance�� NULL�϶� ���� �����Ѵ�.
                if (instance == null)
                {
                    instance = GameObject.Instantiate(Resources.Load<T>("MonoSingleton/" + typeof(T).Name));
                    DontDestroyOnLoad(instance.gameObject);
                }
                return instance;
            }
        }
    }

    private void OnDisable()
    {
        IsQuitting = true;
        instance = null;
    }
}
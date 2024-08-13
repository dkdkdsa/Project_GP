/*
* Class: ResourceManager
* Author: 최대원
* Created: 2024년 6월 19일 수요일
* Description: 리소스 관리 매니저
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Object = UnityEngine.Object;

public class ResourceManager : MonoSingleton<ResourceManager>
{

    /// <summary>
    /// 실행시 먼저 불러올 Label
    /// </summary>
    [SerializeField] private List<AssetLabelReference> _firstLoadLabels;

    /// <summary>
    /// 로딩된 에셋 저장소
    /// </summary>
    private Dictionary<int, Object> _assetContainer = new();

    /// <summary>
    /// 타겟 로딩 카운트
    /// </summary>
    private int _targetLoadCount;

    /// <summary>
    /// 합계 로딩 카운트
    /// </summary>
    private int _totalLoadCount;

    /// <summary>
    /// 에셋 키의 해시코드를 반환
    /// </summary>
    /// <param name="key">key</param>
    /// <returns>hash</returns>
    public static int GenerateHash(string key)
    {

        return key.GetHashCode();

    }

    private void Awake()
    {
        
        Init();

    }

    public void Init()
    {

        _targetLoadCount = _firstLoadLabels.Count;

        foreach (var label in _firstLoadLabels)
        {

            var handle = Addressables.LoadResourceLocationsAsync(label.labelString);
            handle.Completed += HandleLoadResourceCompleted;

        }

    }

    /// <summary>
    /// 로딩이 전부 끝남
    /// </summary>
    private void LoadingEnd()
    {

        _totalLoadCount++;

        if(_totalLoadCount == _targetLoadCount)
        {

            Debug.Log("로딩 끝");

        }

    }

    /// <summary>
    /// 단일 에셋을 로딩
    /// </summary>
    /// <param name="key">로딩 할 에셋의 키</param>
    /// <returns>로딩된 에셋</returns>
    public T LoadAsset<T>(string key) where T : Object
    {

        int hash = GenerateHash(key);

        if (_assetContainer.TryGetValue(hash, out var obj))
        {

            return obj as T;

        }

        var handle = Addressables.LoadAssetAsync<T>(key);
        handle.WaitForCompletion();

        return handle.Result;

    }

    /// <summary>
    /// 리소스 로딩이 완료됨
    /// </summary>
    /// <param name="handle"></param>
    private void HandleLoadResourceCompleted(AsyncOperationHandle<IList<IResourceLocation>> handle)
    {

        int total = handle.Result.Count;
        int current = 0;

        foreach (var key in handle.Result)
        {

            var h = Addressables.LoadAssetAsync<Object>(key);

            current++;
            //변수 캡쳐 방지를 위한 복사
            int c = current;

            h.Completed += (res) =>
            {

                var hash = GenerateHash(key.PrimaryKey);

                if (!_assetContainer.ContainsKey(hash))
                {

                    _assetContainer.Add(hash, res.Result);

                }
                else
                {

                    Debug.LogError($"리소스 로딩중 키 중복을 발견 = 키 : {key.PrimaryKey} 이름 : {res.Result.name}");

                }

                if (c == total)
                {

                    LoadingEnd();

                }

            };

        }

    }

    /// <summary>
    /// 로딩된 에셋을 가져옴
    /// </summary>
    /// <typeparam name="T">변환 타입</typeparam>
    /// <param name="key">오브젝트의 키</param>
    /// <returns>오브젝트</returns>
    public T GetAsset<T>(string key) where T : Object
    {

        int hash = GenerateHash(key);
        return GetAsset<T>(hash);

    }

    /// <summary>
    /// 로딩된 에셋을 가져옴
    /// </summary>
    /// <typeparam name="T">변환 타입</typeparam>
    /// <param name="hash">오브젝트의 해시</param>
    /// <returns>오브젝트</returns>
    public T GetAsset<T>(int hash) where T : Object
    {

        if (_assetContainer.TryGetValue(hash, out var obj))
        {

            return obj as T;

        }

        return null;

    }

}

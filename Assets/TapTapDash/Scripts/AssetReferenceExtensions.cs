using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace TapTapDash.Scripts
{
    public static class AssetReferenceExtensions
    {
        public static async UniTask<TObject> LoadAssetOrGetAsync<TObject>(this AssetReferenceT<TObject> sources) 
            where TObject : UnityEngine.Object
        {
            if (sources.Asset == null)
            {
                while (!sources.IsDone)
                {
                    await UniTask.Yield();
                }
            }
            
            if (sources.Asset != null)
                return sources.Asset as TObject;
            
            return await sources.LoadAssetAsync<TObject>();
        }
    }
}
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace Posterboy
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;

        void Start()
		{

			GorillaTagger.OnPlayerSpawned(Init);
		}

		void Init()
		{
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PosterBoy.AssetBundles.posties");
            bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>("BundleParent (put objects in here DONT MOVE)"));
            assetBundleParent.transform.position = new Vector3(-67.2225f, 11.57f, -82.611f);
        }
    }
}

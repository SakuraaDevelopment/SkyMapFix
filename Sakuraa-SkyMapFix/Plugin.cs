using System;
using BepInEx;
using UnityEngine;
using Utilla;

namespace Sakuraa_SkyMapFix
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
        private GameObject skyJungleBottom;
        private GameObject cityToSkyJungle;
        private GameObject treeAnchor;
        private GameObject city;
        private GameObject skymap;

        void Start()
        {
            skyJungleBottom = GameObject.Find("Environment Objects/LocalObjects_Prefab/SkyJungleBottom");
            cityToSkyJungle = GameObject.Find("Environment Objects/LocalObjects_Prefab/CityToSkyJungle");
            
            city = GameObject.Find("Environment Objects/LocalObjects_Prefab/City");
            skymap = GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle");

            if (city == null)
            {
                Debug.LogError("SkyMapFix: City GameObject not found!");
                return;
            }
        }

        void HideSky()
        {
            skyJungleBottom.SetActive(false);
            cityToSkyJungle.SetActive(false);
        }

        void ShowSky()
        {
            skyJungleBottom.SetActive(true);
            cityToSkyJungle.SetActive(true);
        }

        void Update()
        {
            if (city.activeSelf || skymap.activeSelf)
            {
                ShowSky();
            }
            else
            {
                HideSky();
            }
        }
    }
}

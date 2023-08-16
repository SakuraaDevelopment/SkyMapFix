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
        private GameObject city;

        void Start()
        {
            skyJungleBottom = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Sky Jungle Bottom (1)");
            cityToSkyJungle = GameObject.Find("Environment Objects/LocalObjects_Prefab/CityToSkyJungle");
            city = GameObject.Find("Environment Objects/LocalObjects_Prefab/City");

            if (city == null)
            {
                Debug.LogError("SkyMapFix: City GameObject not found!");
                return;
            }

            if (skyJungleBottom != null)
            {
                skyJungleBottom.SetActive(false);
            }

            if (cityToSkyJungle != null)
            {
                cityToSkyJungle.SetActive(false);
            }
        }

        void Update()
        {
            if (city == null)
            {
                Debug.LogError("SkyMapFix: City GameObject not found!");
                return;
            }

            if (city.activeSelf)
            {
                if (skyJungleBottom != null)
                {
                    skyJungleBottom.SetActive(true);
                }

                if (cityToSkyJungle != null)
                {
                    cityToSkyJungle.SetActive(true);
                }
            }
            else
            {
                if (skyJungleBottom != null)
                {
                    skyJungleBottom.SetActive(false);
                }

                if (cityToSkyJungle != null)
                {
                    cityToSkyJungle.SetActive(false);
                }
            }
        }
    }
}

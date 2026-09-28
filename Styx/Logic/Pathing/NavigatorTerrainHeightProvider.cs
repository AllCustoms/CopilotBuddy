using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Styx.WoWInternals;
using TripperNav = Tripper.Navigation;

namespace Styx.Logic.Pathing
{
    // HB 6.2.3 Class1050: queries navmesh polygons via QueryPolygons + GetPolyHeight.
    internal class NavigatorTerrainHeightProvider : ITerrainHeightProvider
    {
        // Native QueryPolygons converts WoW extents to Detour extents as (Y, Z, X),
        // so HB's Detour-space (1, 50000, 1) must be passed here as WoW-space (1, 1, 50000).
        private static readonly Vector3 HeightSearchExtents = new Vector3(1f, 1f, 50000f);

        public List<float> FindHeights(float x, float y)
        {
            var heights = new List<float>();
            if (!Navigator.IsNavigatorLoaded)
                return heights;

            uint mapId = StyxWoW.Me?.MapId ?? 0;

            var center = new Vector3(x, y, 0f);
            TripperNav.PolygonReference[] polygons = Navigator.TripperNavigator.QueryPolygons(mapId, center, HeightSearchExtents, 256);
            foreach (TripperNav.PolygonReference polygon in polygons)
            {
                if (!Navigator.TripperNavigator.ClosestPointOnPolyBoundary(mapId, polygon, center, out Vector3 boundaryPoint))
                    continue;

                if (Vector3.DistanceSquared(boundaryPoint, center) > 0.005f)
                    continue;

                if (!Navigator.TripperNavigator.GetPolyHeight(mapId, polygon, center, out float height))
                    continue;

                if (heights.All(existingHeight => Math.Abs(existingHeight - height) > 1f))
                    heights.Add(height);
            }

            return heights;
        }
    }
}

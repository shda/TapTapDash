using System;
using System.Collections.Generic;
using System.Linq;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TapTapDash.Scripts
{
    public class TileMapLevel : MonoBehaviour
    {
        [SerializeField] private SuperMap map;
        [SerializeField] private Tilemap tilemap;

        public Vector3 StartPosition;
        public Vector3 FinishPosition;

        private void Awake()
        {
            StartPosition = CalcStartPoint("start");
            FinishPosition = CalcStartPoint("finish");
        }

        private void Start()
        {
            foreach (var pos in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(pos);
                
                if (tile)
                {
                    if (tile is SuperTile superTile)
                    {
                        Matrix4x4 transformMatrix = tilemap.GetTransformMatrix(pos);
                        Quaternion rotation = transformMatrix.rotation;
                        if (rotation != Quaternion.identity)
                        {
                            Debug.Log($"Тайл в {pos} повёрнут на угол: {rotation.eulerAngles}");
                        }
                    }
                }
            }
        }

        public float GetAngleTile(Vector3 position)
        {
            return 0;
            
            var pos = tilemap.WorldToCell(position);
            var tile = tilemap.GetTile(pos);

            if (!tile)
                return 0.0f;
            
            if (tile is SuperTile superTile)
            {
                /*
                if (superTile.TryGetProperty("isJump", out CustomProperty property))
                {
                    return property.GetValueAsBool();
                }
                */
            }

            return 0;
        }

        public bool TryGetIJump(Vector3 position)
        {
            var pos = tilemap.WorldToCell(position);
            var tile = tilemap.GetTile(pos);
            
            if (!tile)
                return false;

            if (tile is SuperTile superTile)
            {
                if (superTile.TryGetProperty("isJump", out CustomProperty property))
                {
                    return property.GetValueAsBool();
                }
            }

            return false;
        }

        public bool TryGetDirectionByTileWorld(Vector3 position , out Direction direction)
        {
            direction = Direction.Left;

            var pos = tilemap.WorldToCell(position);
            var tile = tilemap.GetTile(pos);
            
            if (!tile)
                return false;

            if (tile is SuperTile superTile)
            {
                if (superTile.TryGetProperty("direction",  out CustomProperty property))
                {
                    direction = property.m_Value switch
                    {
                        "left" => Direction.Left,
                        "right" => Direction.Right,
                        "up" => Direction.Up,
                        "down" => Direction.Down,
                        _ => direction
                    };

                    return true;
                }
            }

            return false;
        }

        private Vector3 CalcStartPoint(string valueByName)
        {
            var tiles = FindTileByNameProperty("name");

            foreach (var tile in tiles)
            {
                var nameValue = tile.Tile.GetPropertyValueAsString("name");
                if (string.Equals(nameValue, valueByName, StringComparison.Ordinal))
                {
                    return  tilemap.GetCellCenterWorld(tile.Position);
                }
            }
            
            throw new Exception("Could not find tile map tile named " + valueByName);
        }

        private SuperTileCoord[] FindTileByNameProperty(string propName)
        {
            var tiles = new List<SuperTileCoord>();
            
            foreach (var pos in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(pos);
                
                if (tile)
                {
                    if (tile is SuperTile superTile)
                    {
                        if (superTile.m_CustomProperties != null)
                        {
                            if (superTile.TryGetProperty(propName,  out CustomProperty property))
                            {
                                tiles.Add(new SuperTileCoord(superTile , pos));
                            }
                        }
                    }
                }
            }
            return tiles.ToArray();
        }
    }
}
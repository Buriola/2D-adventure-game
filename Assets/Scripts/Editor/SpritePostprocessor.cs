using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class SpritePostprocessor : AssetPostprocessor
    {
        private void OnPostprocessTexture(Texture2D texture)
        {
            TextureImporter importer = (TextureImporter) assetImporter;
            
            if (importer.assetPath.Contains("Sprites"))
            {
                importer.textureType = TextureImporterType.Sprite;
                importer.spritePixelsPerUnit = 16;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.crunchedCompression = false;
                importer.filterMode = FilterMode.Point;
                importer.isReadable = true;
                importer.wrapMode = TextureWrapMode.Repeat;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
            }
        }
    }
}

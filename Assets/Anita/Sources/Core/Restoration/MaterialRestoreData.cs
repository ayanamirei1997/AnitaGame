using System;
using System.Collections.Generic;

namespace Anita
{
    [Serializable]
    public class MaterialRestoreData : IRestoreData
    {
        public bool isRestorableMaterial;

        public string shaderName;

        // color info
        public readonly Dictionary<string, Vector4Data> colorDatas = new Dictionary<string, Vector4Data>();

        // vector info
        public readonly Dictionary<string, Vector4Data> vectorDatas = new Dictionary<string, Vector4Data>();

        // float and range info
        public readonly Dictionary<string, float> floatDatas = new Dictionary<string, float>();

        // binded texture names
        public readonly Dictionary<string, string> textureNames = new Dictionary<string, string>();

        // scale and offset of the texture
        public readonly Dictionary<string, Vector4Data> textureScaleOffsets = new Dictionary<string, Vector4Data>();
    }
}
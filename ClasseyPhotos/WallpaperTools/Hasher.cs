﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace WallpaperTools
{
    public class Hasher : IDisposable
    {
        private readonly MD5 md5;

        public Hasher()
        {
            md5 = MD5.Create();
        }


        public void Dispose()
        {
            md5?.Dispose();
        }

/*
        public List<string> ComputeHashes(IEnumerable<Image> images)
        {
            var hashList = new List<string>();

            foreach (var image in images)
            {
                var hash = ComputeImageHash(image);
                hashList.Add(hash);
            }

            return hashList;
        }
*/

/*
        public string ComputeImageHash(Image image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Bmp);
                var hash = Hash(memoryStream);
                return hash;
            }
        }
*/

        public string ComputeImageHashFromPath(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return Hash(stream);
            }
        }

        private string Hash(Stream stream)
        {
            var hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
            return hash;
        }

/*
        public string Hash(byte[] byteArray)
        {
            var hash = BitConverter.ToString(md5.ComputeHash(byteArray)).Replace("-", "").ToLower();
            return hash;
        }
*/
    }
}
﻿using System.Collections.Generic;

namespace Bamboo.Protocol
{
    class DataBuffer : IReadable, IWritable
    {
        private int Cursor = 0;
        public readonly List<byte> Buffer;
        public int Length = 0;

        public DataBuffer()
        {
            Buffer = new List<byte>();
        }

        public DataBuffer(byte[] bytes)
        {
            Buffer = new List<byte>(bytes);
            Length = Buffer.Count;
        }

        public byte[] Read(int length)
        {
            // Write the data into a new buffer
            byte[] bytes = Buffer.GetRange(Cursor, length).ToArray();
            Cursor += length;

            return bytes;
        }

        public void Write(byte[] bytes)
        {
            Buffer.InsertRange(Cursor, bytes);
            Cursor += bytes.Length;
            Length += bytes.Length;
        }
    }
}
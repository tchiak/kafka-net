﻿using System;
using Kafka.Client.Common.Imported;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kafka.Test.New
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBitOrder()
        {
            ByteBuffer stream = ByteBuffer.Allocate(14);
            stream.PutShort(0x1234);
            Assert.AreEqual(2, stream.Position);
            stream.PutInt(0x56789ABC);
            Assert.AreEqual(2 + 4, stream.Position);
            stream.PutLong(0x1234567890ABCDEF);
            Assert.AreEqual(2 + 4 + 8, stream.Position);

            var expectedBytes = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            for (var i = 0; i < expectedBytes.Length; i++)
            {
                Assert.AreEqual(expectedBytes[i], stream.Array[i]);
            }
        }
    }
}

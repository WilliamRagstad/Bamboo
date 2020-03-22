﻿using Bamboo.Server;

namespace Bamboo.Protocol.States.Login
{
    class SetCompressionPacket : ClientboundPacket
    {
        public override int PacketID { get => 0x03; }

        public SetCompressionPacket(Client client) : base(client) { }

        public override void Write(IWritable buffer)
        {
            DataWriter writer = new DataWriter(buffer);

            writer.WriteVarInt(Settings.CompressionThreshold);

            Client.Compression = CompressionState.Enabling;
        }
    }
}

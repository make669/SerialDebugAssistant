using System;
using Models.Enums;

namespace Services.Interfaces
{
    public interface IChecksumService
    {
        byte[] ComputeChecksumBytes(byte[]? data, ChecksumType checksumType);

        string ComputeChecksumHex(byte[]? data, ChecksumType checksumType, bool upperCase = true, string separator = " ");

        bool ValidateChecksum(byte[]? data, ChecksumType checksumType, byte[]? expectedChecksum);
    }
}

using System;
using Models.Enums;
using Services.Interfaces;
using Utils;

namespace Services
{
    public class ChecksumService : IChecksumService
    {
        public byte[] ComputeChecksumBytes(byte[]? data, ChecksumType checksumType)
        {
            var payload = data ?? Array.Empty<byte>();

            return checksumType switch
            {
                ChecksumType.None => Array.Empty<byte>(),
                ChecksumType.Bcc => new[] { ComputeBcc(payload) },
                ChecksumType.Sum => new[] { ComputeSum(payload) },
                ChecksumType.Lrc => new[] { ComputeLrc(payload) },
                ChecksumType.Crc16 => BitConverter.GetBytes(ComputeCrc16(payload)),
                _ => throw new ArgumentOutOfRangeException(nameof(checksumType), checksumType, "未知校验类型。")
            };
        }

        public string ComputeChecksumHex(byte[]? data, ChecksumType checksumType, bool upperCase = true, string separator = " ")
        {
            var checksumBytes = ComputeChecksumBytes(data, checksumType);
            return HexConverter.ToHexString(checksumBytes, upperCase, separator);
        }

        public bool ValidateChecksum(byte[]? data, ChecksumType checksumType, byte[]? expectedChecksum)
        {
            var actual = ComputeChecksumBytes(data, checksumType);
            var expected = expectedChecksum ?? Array.Empty<byte>();
            return actual.SequenceEqual(expected);
        }

        private static byte ComputeBcc(ReadOnlySpan<byte> data)
        {
            byte checksum = 0;
            foreach (var b in data)
            {
                checksum ^= b;
            }

            return checksum;
        }

        private static byte ComputeSum(ReadOnlySpan<byte> data)
        {
            var sum = 0;
            foreach (var b in data)
            {
                sum += b;
            }

            return (byte)(sum & 0xFF);
        }

        private static byte ComputeLrc(ReadOnlySpan<byte> data)
        {
            var sum = 0;
            foreach (var b in data)
            {
                sum += b;
            }

            return (byte)((-sum) & 0xFF);
        }

        private static ushort ComputeCrc16(ReadOnlySpan<byte> data)
        {
            const ushort polynomial = 0xA001;
            ushort crc = 0xFFFF;

            foreach (var b in data)
            {
                crc ^= b;
                for (var i = 0; i < 8; i++)
                {
                    var lsb = (crc & 0x0001) == 0x0001;
                    crc >>= 1;
                    if (lsb)
                    {
                        crc ^= polynomial;
                    }
                }
            }

            return crc;
        }
    }
}

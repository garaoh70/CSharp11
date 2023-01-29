namespace CSharp11.CS11;

public class Utf8StringLiterals
{
    public byte[] Utf8Bytes { get; init; }

    public ReadOnlySpan<byte> Utf8String => Utf8Bytes;

    public Utf8StringLiterals(ReadOnlySpan<byte> utf8) => Utf8Bytes = utf8.ToArray();
}
using System.Text;
using CSharp11.CS11;

namespace CSharp11UnitTest;

public class Tests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Utf8StringLiteralsUnitTest1()
    {
        // https://mothereff.in/utf-8 を参考
        var utf8string = "1234567890"u8;
        var utf8byte = new byte[] { 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30 };

        var utf8 = new Utf8StringLiterals(utf8string);
        Assert.That(utf8.Utf8Bytes.Length, Is.EqualTo(utf8byte.Length));
        Assert.That(utf8.Utf8Bytes.Zip(utf8byte, (a, b) => a == b).All(x => x), Is.True);
    }

    [Test]
    public void Utf8StringLiteralsUnitTest2()
    {
        // https://mothereff.in/utf-8 を参考
        var utf8string = "🍔"u8;
        var utf8byte = new byte[] { 0xF0, 0x9F, 0x8D, 0x94 };

        var utf8 = new Utf8StringLiterals(utf8string);
        Assert.That(utf8.Utf8Bytes.Length, Is.EqualTo(utf8byte.Length));
        Assert.That(utf8.Utf8Bytes.Zip(utf8byte, (a, b) => a == b).All(x => x), Is.True);
    }

    [Test]
    public void RawStringLiteralsUnitTest1()
    {
        var year = 2023;
        var month = 1;
        var day = 29;
        var orgstring = "Today is \"2023/1/29\".";

        var rawstring1 = """Today is "2023/1/29".""";
        var rawstring2 = $$"""Today is "{{year}}/{{month}}/{{day}}".""";

        var raw1 = new RawStringLiterals(rawstring1);
        var raw2 = new RawStringLiterals(rawstring2);

        Assert.That(raw1.Raw, Is.EqualTo(orgstring));
        Assert.That(raw2.Raw, Is.EqualTo(orgstring));
    }

    [Test]
    public void RawStringLiteralsUnitTest2()
    {
        // インデントが適用されている（日本語おかしい）
        // 最終行には改行は入っていない模様
        var rawstring1 = """
            Today is "2023/1/29".
            Nice to meet you.
            """;

        var sb = new StringBuilder();
        sb.AppendLine("Today is \"2023/1/29\".");
        sb.Append("Nice to meet you.");
        var orgstring = sb.ToString();

        var raw1 = new RawStringLiterals(rawstring1);

        Assert.That(raw1.Raw, Is.EqualTo(orgstring));
    }
}

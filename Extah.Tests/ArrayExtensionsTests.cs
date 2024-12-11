using Shouldly;

namespace Extah.Tests;

[TestClass]
public class ArrayExtensionsTests
{
    [TestMethod]
    public void CreateCombinedArray()
    {
        int[] three = [1, 2, 3];
        int[] four = [1, 2, 3, 4];
        int[] combined = three.Append(four);

        combined.ShouldBeEquivalentTo(new int[] { 1, 2, 3, 1, 2, 3, 4 });
    }

    [TestMethod]
    public void Append_EmptySecondArray()
    {
        int[] three = [1, 2, 3];
        int[] four = [];
        int[] combined = three.Append(four);

        combined.ShouldBeEquivalentTo(three);
    }

    [TestMethod]
    public void Append_NullSecondArray()
    {
        int[] three = [1, 2, 3];
        int[]? four = null;
        int[] combined = three.Append(four!);

        combined.ShouldBeEquivalentTo(three);
    }
}
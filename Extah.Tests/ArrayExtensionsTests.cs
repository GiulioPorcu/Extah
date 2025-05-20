using Shouldly;

namespace Extah.Tests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        private static readonly int[] expectedTwo = [1, 2, 3, 1, 2, 3, 4];
        private static readonly int[] expectedThree = [1, 2, 3, 1, 2, 3, 4, 1, 2, 3, 4, 5];

        [TestMethod]
        public void Append_Normally_Two()
        {
            int[] first = [1, 2, 3];
            int[] second = [1, 2, 3, 4];
            int[] combined = first.Append(second);
            combined.ShouldBeEquivalentTo(expectedTwo);
        }

        [TestMethod]
        public void Append_Normally_Three()
        {
            int[] first = [1, 2, 3];
            int[] second = [1, 2, 3, 4];
            int[] third = [1, 2, 3, 4, 5];
            int[] combined = first.Append(second).Append(third);
            combined.ShouldBeEquivalentTo(expectedThree);
        }

        [TestMethod]
        public void Append_Normally_DynamicArrays()
        {
            int[] target = [];
            int[]? current = null;
            IList<int> values = [];

            for (int i = 0; i < 999; i++)
            {
                if (i % 3 == 0)
                {
                    target = target.Append(current!);
                    current = new int[3];
                }

                current![i % 3] = i;
                values.Add(i);
            }

            target = target.Append(current!);

            for (int i = 0; i < values.Count; i++)
            {
                target[i].ShouldBeEquivalentTo(values[i]);
            }
        }

        [TestMethod]
        public void Append_FirstArrayEmpty()
        {
            int[] first = [];
            int[] second = [1, 2, 3];
            int[] combined = first.Append(second);
            combined.ShouldBeEquivalentTo(second);
        }

        [TestMethod]
        public void Append_SecondArrayEmpty()
        {
            int[] first = [1, 2, 3];
            int[] second = [];
            int[] combined = first.Append(second);
            combined.ShouldBeEquivalentTo(first);
        }

        [TestMethod]
        public void Append_BothArraysEmpty()
        {
            int[] first = [];
            int[] second = [];
            int[] combined = first.Append(second);
            combined.ShouldBeEquivalentTo(Array.Empty<int>());
        }

        [TestMethod]
        public void Append_FirstArrayNull()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            int[]? first = null;
            int[] second = [1, 2, 3];
            Should.Throw<ArgumentNullException>(() => first.Append(second));
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [TestMethod]
        public void Append_SecondArrayNull()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            int[] first = [1, 2, 3];
            int[]? second = null;
            int[] combined = first.Append(second);
            combined.ShouldBeEquivalentTo(first);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [TestMethod]
        public void Append_BothArraysNull()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            int[]? first = null;
            int[]? second = null;
            Should.Throw<ArgumentNullException>(() => first.Append(second));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
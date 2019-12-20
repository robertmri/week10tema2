using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    [TestFixture]
    class UT_StringProblem
    {
        [TestCase("ab-cd", "dc-ba")]
        [TestCase("a-bC-dEf-ghIj", "j-Ih-gfE-dCba")]
        [TestCase("Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!")]
       
        public static void TestRevMethod(string input, string expected)
        {
            string current = StringsProblem.ReverseString(input);

            Assert.AreEqual(expected, current);
        }

        [TestCase("")]
        public static void TestRevMethodExcept(string input)
        {
            Assert.Throws<InvalidOperationException>(() => StringsProblem.ReverseString(input));
        }
    }
}

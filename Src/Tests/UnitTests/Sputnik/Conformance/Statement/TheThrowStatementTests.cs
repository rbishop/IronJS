// <auto-generated />
namespace IronJS.Tests.UnitTests.Sputnik.Conformance.Statement
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class TheThrowStatementTests : SputnikTestFixture
    {
        public TheThrowStatementTests()
            : base(@"Conformance\12_Statement\12.13_The_throw_statement")
        {
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.13")]
        [TestCase("S12.13_A1.js", Description = "Sanity test for throw statement", ExpectedException = typeof(Exception))]
        public void SanityTestForThrowStatement(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.13")]
        [TestCase("S12.13_A2_T1.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        [TestCase("S12.13_A2_T2.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        [TestCase("S12.13_A2_T3.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        [TestCase("S12.13_A2_T4.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        [TestCase("S12.13_A2_T5.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        [TestCase("S12.13_A2_T6.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        [TestCase("S12.13_A2_T7.js", Description = "\"throw Expression\" returns (throw, GetValue(Result(1)), empty), where 1 evaluates Expression")]
        public void ThrowExpressionReturnsThrowGetValueResult1EmptyWhere1EvaluatesExpression(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.13")]
        [TestCase("S12.13_A3_T1.js", Description = "1. Evaluate Expression")]
        [TestCase("S12.13_A3_T2.js", Description = "1. Evaluate Expression")]
        [TestCase("S12.13_A3_T3.js", Description = "1. Evaluate Expression")]
        [TestCase("S12.13_A3_T4.js", Description = "1. Evaluate Expression")]
        [TestCase("S12.13_A3_T5.js", Description = "1. Evaluate Expression")]
        [TestCase("S12.13_A3_T6.js", Description = "1. Evaluate Expression")]
        public void _1EvaluateExpression(string file)
        {
            RunFile(file);
        }
    }
}
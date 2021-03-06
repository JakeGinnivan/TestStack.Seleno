﻿using System;

using TestStack.Seleno.PageObjects;

using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects.Actions;

namespace TestStack.Seleno.Tests.PageObjects
{
    [TestFixture]
    public class when_executing_script_and_changing_return_type_with_UiComponent
    {
        private ScriptExecutor SUT;
        protected IJavaScriptExecutor _fakeJavaScriptExecutor;
        protected Type _expectedType = typeof(bool);
        protected string executedScript = "$('#id').is(':visible')";
        protected object _result;

        public when_executing_script_and_changing_return_type_with_UiComponent()
        {
            SUT = new ScriptExecutor(null, null, null);
            _fakeJavaScriptExecutor = Substitute.For<IJavaScriptExecutor>();

            _fakeJavaScriptExecutor
                .ExecuteScript(Arg.Any<string>())
                .Returns("true");

            _result = SUT.ScriptAndReturn(executedScript, _expectedType, _fakeJavaScriptExecutor);
        }

        [Test]
        public void should_execute_given_javascript()
        {
            _fakeJavaScriptExecutor.Received().ExecuteScript("return " + executedScript);
        }

        [Test]
        public void should_cast_the_return_type_to_the_specified_type()
        {
            _result.Should().BeOfType<bool>();
        }
    }
}
﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Products.Tests.Integration.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class NegativeProductPriceFeature : object, Xunit.IClassFixture<NegativeProductPriceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "NegativePrice.feature"
#line hidden
        
        public NegativeProductPriceFeature(NegativeProductPriceFeature.FixtureData fixtureData, Products_Tests_Integration_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Negative Product Price", "        As a user of the system\r\n        I want to ensure that product prices are" +
                    " valid\r\n        So that I don\'t add products with negative prices", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Failing to create a product with a negative price")]
        [Xunit.TraitAttribute("FeatureTitle", "Negative Product Price")]
        [Xunit.TraitAttribute("Description", "Failing to create a product with a negative price")]
        [Xunit.TraitAttribute("Category", "createProductNegativePrice")]
        public void FailingToCreateAProductWithANegativePrice()
        {
            string[] tagsOfScenario = new string[] {
                    "createProductNegativePrice"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Failing to create a product with a negative price", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Quantity",
                            "Price",
                            "Description"});
                table4.AddRow(new string[] {
                            "ValidName",
                            "5",
                            "-49.99",
                            "A product"});
#line 8
        testRunner.Given("I have the following product details:", ((string)(null)), table4, "Given ");
#line hidden
#line 11
        testRunner.When("I attempt to create the product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
        testRunner.Then("the system should reject the product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
        testRunner.And("I should see an error message indicating invalid price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                NegativeProductPriceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                NegativeProductPriceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
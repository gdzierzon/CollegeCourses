﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CollegeUnitTests.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AddCourses")]
    public partial class AddCoursesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AddCourses.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AddCourses", "\tIn order to verify courses that I have added\r\n\tAs a university administrator\r\n\tI" +
                    " want to be shown a sequential list of my courses", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add Courses to College")]
        public virtual void AddCoursesToCollege()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Courses to College", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I am adding courses to a college", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "courseList",
                        "schedule"});
            table1.AddRow(new string[] {
                        @"Introduction to Paper Airplanes:,Advanced Throwing Techniques: Introduction to Paper Airplanes,History of Cubicle Siege Engines: Rubber Band Catapults 101,Advanced Office Warfare: History of Cubicle Siege Engines,Rubber Band Catapults 101: ,Paper Jet Engines: Introduction to Paper Airplanes",
                        "Introduction to Paper Airplanes, Advanced Throwing Techniques, Paper Jet Engines," +
                            " Rubber Band Catapults 101, History of Cubicle Siege Engines, Advanced Office Wa" +
                            "rfare"});
            table1.AddRow(new string[] {
                        "Intro to Arguing on the Internet: Godwin’s Law, Understanding Circular Logic: Int" +
                            "ro to Arguing on the Internet, Godwin’s Law: Understanding Circular Logic",
                        "\'Understanding Circular Logic\' has a prerequisite course with a circular referenc" +
                            "e."});
#line 8
 testRunner.Then("the courseList list should display schedule", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

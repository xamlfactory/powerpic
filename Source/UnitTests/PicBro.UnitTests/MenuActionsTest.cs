using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace PicBro.UnitTests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MenuActionsTest
    {
        public MenuActionsTest()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            this.UIMap.LaunchApplication();
        }

        [TestMethod]
        public void MenuActionsTest_TestAddDirectory()
        {
            this.UIMap.AddTestDirectory();
            this.UIMap.AssertFoldersList();

        }

        [TestMethod]
        public void MenuActionsTest_ChangeFolderSelection()
        {
            this.UIMap.SelectFavorites();
            this.UIMap.AssertImagesList(0);
            this.UIMap.SelectTest();
            this.UIMap.AssertImagesList(3);
            this.UIMap.SelectTest1();
            this.UIMap.AssertImagesList(4);
        }

        [TestMethod]
        public void MenuActionsTest_TestImageFullView()
        {
            this.UIMap.LaunchFullView();
            this.UIMap.AssertImageDetails();
        }

        [TestMethod]
        public void MenuActionsTest_TestFavorites()
        {
            this.UIMap.AddImageToFavorites();
            this.UIMap.AssertImagesList(1);
        }

        [TestMethod]
        public void MenuActionsTest_AddTags()
        {
            this.UIMap.LaunchFullView();
            this.UIMap.AddTags("TAG");
            this.UIMap.NavigateToNextImage();
            this.UIMap.AddTags("TAG");
            this.UIMap.CloseApplication();
        }

        [TestMethod]
        public void MenuActionsTest_AssertTags()
        {
            this.UIMap.LaunchFullView();
            this.UIMap.AssertTags(2);
            this.UIMap.NavigateToNextImage();
            this.UIMap.AssertTags(2);
            this.UIMap.NavigateToNextImage();
            this.UIMap.AssertTags(1);
        }

        [TestMethod]
        public void MenuActionsTest_SearchTags()
        {
            this.UIMap.Search("tag");
            this.UIMap.AssertImagesList(2);
            this.UIMap.GoBackToBrowseView();
            this.UIMap.Search("1");
            this.UIMap.AssertImagesList(2);
            this.UIMap.GoBackToBrowseView();
            this.UIMap.Search("test");
            this.UIMap.AssertImagesList(0);
            this.UIMap.GoBackToBrowseView();
            this.UIMap.Search("1,tag");
            this.UIMap.AssertImagesList(1);
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}

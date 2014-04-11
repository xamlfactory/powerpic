namespace PicBro.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    using System.IO;


    public partial class UIMap
    {

        /// <summary>
        /// AddTestDirectory - Use 'AddTestDirectoryParams' to pass parameters into this method.
        /// </summary>
        public void AddTestDirectory()
        {
            #region Variable Declarations
            WpfMenuItem uIAdddirectoryMenuItem = this.UIPicbroWindow.UIItemCustom.UIItemMenu.UIFILEMenuItem.UIAdddirectoryMenuItem;
            WinTreeItem uIDesktopTreeItem = this.UIBrowseForFolderWindow.UITreeViewWindow.UIDesktopTreeItem;
            WinTreeItem uITestTreeItem = this.UIBrowseForFolderWindow.UITreeViewWindow.UIDesktopTreeItem.UITestTreeItem;
            WinButton uIOKButton = this.UIBrowseForFolderWindow.UIOKWindow.UIOKButton;
            #endregion

            // Click 'FILE' -> 'Add directory' menu item
            Mouse.Click(uIAdddirectoryMenuItem, new Point(37, 11));

            // Click 'Desktop' tree item
            Mouse.Click(uIDesktopTreeItem, new Point(26, 7));

            Keyboard.SendKeys(uIDesktopTreeItem, "{End}", ModifierKeys.None);

            // Expand 'Desktop' -> 'Test' tree item
            uITestTreeItem.Expanded = true;

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(37, 10));
        }

        /// <summary>
        /// AssertTutorialConfirmationDialog - Use 'AssertTutorialConfirmationDialogExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertTutorialConfirmationDialog()
        {
            #region Variable Declarations
            WpfWindow uIPleaseConfirmWindow = this.UIPleaseConfirmWindow;
            #endregion

            // Verify that the 'Exists' property of 'Please Confirm?' window equals 'True'
            Assert.AreEqual(true, uIPleaseConfirmWindow.Exists, "Tutorial Confirmation Dialog not opened.");
        }


        /// <summary>
        /// AssertTutorialWindow - Use 'AssertTutorialWindowExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertTutorialWindow()
        {
            #region Variable Declarations
            WinWindow uITutorialWindow1 = this.UITutorialWindow1;
            #endregion

            // Verify that the 'Exists' property of 'Tutorial' window equals 'True'
            Assert.AreEqual(true, uITutorialWindow1.Exists, "Tutorial Window not opened");
        }

        public void AssertEmptyFolderList()
        {
            WpfList uIFolderListBoxList = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList;
            Assert.AreEqual(1, uIFolderListBoxList.Items.Count);
            WpfListItem uIFavoritesListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UIFavoritesListItem;
            Assert.IsTrue(uIFavoritesListItem.Exists);
        }

        /// <summary>
        /// ConfirmTutorialConfirmationDialog
        /// </summary>
        public void ConfirmTutorialConfirmationDialog()
        {
            #region Variable Declarations
            WpfButton uIYesButton = this.UIPleaseConfirmWindow.UIYesButton;
            #endregion

            // Click 'Yes' button
            Mouse.Click(uIYesButton, new Point(45, 14));
        }

        /// <summary>
        /// DeleteAppData - Use 'DeleteAppDataParams' to pass parameters into this method.
        /// </summary>
        public void DeleteAppData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Picbro\";
            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                info.Delete(true);
            }
        }

        /// <summary>
        /// LaunchApplication - Use 'LaunchApplicationParams' to pass parameters into this method.
        /// </summary>
        public void LaunchApplication()
        {
            // Launch 'E:\Workspace\PowerPic\Main\Source\Build\PicBro.Shell.Windows.exe'
            ApplicationUnderTest picBroShellWindowsApplication = ApplicationUnderTest.Launch(@"E:\Workspace\PowerPic\Main\Source\Build\PicBro.Shell.Windows.exe", @"E:\Workspace\PowerPic\Main\Source\Build\PicBro.Shell.Windows.exe");
        }

        /// <summary>
        /// AssertFoldersList - Use 'AssertFoldersListExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertFoldersList()
        {
            WpfProgressBar uIItemProgressBar = this.UIPicbroWindow.UIItemCustom3.UISLIDESHOWText.UIItemProgressBar;
            uIItemProgressBar.WaitForControlPropertyEqual("Position", 100);

            #region Variable Declarations
            WpfList uIFolderListBoxList = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList;
            WpfListItem uIFavoritesListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UIFavoritesListItem;
            #endregion

            Assert.AreEqual(3, uIFolderListBoxList.Items.Count);
            // Verify that the 'SelectedItemsAsString' property of 'FolderListBox' list box equals 'Test1'
            Assert.AreEqual("Test1", uIFolderListBoxList.SelectedItemsAsString, "Test1 not selected.");

            // Verify that the 'Exists' property of 'Favorites' list item equals 'True'
            Assert.AreEqual(true, uIFavoritesListItem.Exists, "Favorites not exists");
        }

        /// <summary>
        /// SelectFavorites
        /// </summary>
        public void SelectFavorites()
        {
            #region Variable Declarations
            WpfListItem uIFavoritesListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UIFavoritesListItem;
            #endregion

            // Click 'Favorites' list item
            Mouse.Click(uIFavoritesListItem, new Point(61, 17));
        }

        /// <summary>
        /// SelectTest
        /// </summary>
        public void SelectTest()
        {
            #region Variable Declarations
            WpfListItem uITestListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UITestListItem;
            #endregion

            // Click 'Test' list item
            Mouse.Click(uITestListItem, new Point(51, 19));
        }

        /// <summary>
        /// SelectTest1
        /// </summary>
        public void SelectTest1()
        {
            #region Variable Declarations
            WpfListItem uITest1ListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UITest1ListItem;
            #endregion

            // Click 'Test1' list item
            Mouse.Click(uITest1ListItem, new Point(101, 9));
        }
        public void AssertImagesList(int count)
        {
            WpfList imagesList = this.UIPicbroWindow.UIItemCustom2.UIListList;
            Assert.AreEqual(count, imagesList.Items.Count);
        }

        /// <summary>
        /// AssertImageDetails - Use 'AssertImageDetailsExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertImageDetails()
        {
            #region Variable Declarations
            WpfText uIItem1jpgText = this.UIPicbroWindow.UIItemCustom4.UIItem1jpgText;
            WpfText uIItem8830KBText = this.UIPicbroWindow.UIItemCustom4.UIItem8830KBText;
            WpfList uIItemList = this.UIPicbroWindow.UIRootCustom.UIItemList;
            #endregion

            // Verify that the 'Name' property of '1.jpg' label equals '1.jpg'
            Assert.AreEqual("1.jpg", uIItem1jpgText.Name);

            // Verify that the 'Name' property of '883.0 KB' label equals '883.0 KB'
            Assert.AreEqual("883.0 KB", uIItem8830KBText.Name);

            // Verify that the 'SelectedItemsAsString' property of list box equals ''
            Assert.AreEqual(1, uIItemList.Items.Count);
        }

        /// <summary>
        /// LaunchFullView
        /// </summary>
        public void LaunchFullView()
        {
            #region Variable Declarations
            WpfList uIListList = this.UIPicbroWindow.UIItemCustom2.UIListList;
            WpfListItem uITestListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UITestListItem;
            WpfImage uISmallThumbImage = this.UIPicbroWindow.UIItemCustom2.UIListList.UIItem1jpgListItem.UISmallThumbImage;
            #endregion

            // Click 'list' list box
            //Mouse.Click(uIListList, new Point(537, 433));

            // Click 'Test' list item
            Mouse.Click(uITestListItem, new Point(41, 11));

            // Double-Click 'SmallThumb' image
            Mouse.DoubleClick(uISmallThumbImage, new Point(48, 47));
        }

        /// <summary>
        /// AddImageToFavorites - Use 'AddImageToFavoritesParams' to pass parameters into this method.
        /// </summary>
        public void AddImageToFavorites()
        {
            #region Variable Declarations
            WpfListItem uITest1ListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UITest1ListItem;
            WpfImage uISmallThumbImage = this.UIPicbroWindow.UIItemCustom2.UIListList.UIItem3pngListItem.UISmallThumbImage;
            WpfToggleButton uIAddtoFavoritesToggleButton = this.UIPicbroWindow.UIItemCustom4.UIAddtoFavoritesToggleButton;
            WpfButton uIBACKButton = this.UIPicbroWindow.UIItemCustom31.UIBACKButton;
            WpfListItem uIFavoritesListItem = this.UIPicbroWindow.UIItemCustom1.UIFolderListBoxList.UIFavoritesListItem;
            #endregion

            // Click 'Test1' list item
            Mouse.Click(uITest1ListItem, new Point(82, 13));

            // Double-Click 'SmallThumb' image
            Mouse.DoubleClick(uISmallThumbImage, new Point(77, 55));

            // Set to 'Pressed' state 'Add to Favorites' toggle button
            uIAddtoFavoritesToggleButton.Pressed = true;

            // Click 'BACK' button
            Mouse.Click(uIBACKButton, new Point(38, 17));

            // Click 'Favorites' list item
            Mouse.Click(uIFavoritesListItem, new Point(61, 11));
        }

        public void GoBackToBrowseView()
        {
            WpfButton uIBACKButton = this.UIPicbroWindow.UIItemCustom31.UIBACKButton;
            // Click 'BACK' button
            Mouse.Click(uIBACKButton, new Point(23, 4));
        }

        public void AddTags(string tag)
        {
            WpfEdit uIItemEdit = this.UIPicbroWindow.UIItemCustom4.UIRootCustom.UITAGSText.UIItemEdit;
            WpfButton uIAddButton = this.UIPicbroWindow.UIItemCustom4.UIRootCustom1.UIAddButton;

            // Type 'TAG' in first text box next to 'TAGS' label
            uIItemEdit.Text = tag;

            // Click 'Add' button
            Mouse.Click(uIAddButton, new Point(16, 13));
        }

        /// <summary>
        /// AssertTags - Use 'AssertTagsExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertTags(int count)
        {
            #region Variable Declarations
            WpfList uIItemList = this.UIPicbroWindow.UIRootCustom.UIItemList;
            #endregion

            // Verify that the 'SelectedItemsAsString' property of list box equals ''
            Assert.AreEqual(count, uIItemList.Items.Count);
        }

        /// <summary>
        /// NavigateToNextImage
        /// </summary>
        public void NavigateToNextImage()
        {
            #region Variable Declarations
            WpfButton uIÀButton = this.UIPicbroWindow.UIImageFullViewUCCustom.UIÀButton;
            #endregion

            // Click 'à' button
            Mouse.Click(uIÀButton, new Point(21, 20));
        }

        /// <summary>
        /// Search - Use 'SearchParams' to pass parameters into this method.
        /// </summary>
        public void Search(string text)
        {
            #region Variable Declarations
            WpfEdit uIItemEdit = this.UIPicbroWindow.UIItemCustom.UIItemEdit;
            #endregion

            // Type 'test' in text box
            uIItemEdit.Text = text;

            // Type '{Enter}' in text box
            Keyboard.SendKeys(uIItemEdit, "{Enter}", ModifierKeys.None);
        }

        /// <summary>
        /// CloseApplication
        /// </summary>
        public void CloseApplication()
        {
            #region Variable Declarations
            WpfButton uIPART_CloseButton = this.UIPicbroWindow.UIPART_CloseButton;
            #endregion

            // Click 'PART_Close' button
            Mouse.Click(uIPART_CloseButton, new Point(16, 19));
        }
    }
}
